using System;
using System.Configuration; // Agregá este using arriba
using System.Configuration;
using System.IO;
using System.IO.Ports;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace PruebaLectura
{
    public partial class FormConfigSerial : Form
    {
        private SerialPort serialPort;
        
        bool continuarLeyendo = false;
        string nombreArchivo;
        private StreamWriter logFile;
        public FormConfigSerial()
        {
            InitializeComponent();

        }

        private void FormConfigSerial_Load(object sender, EventArgs e)
        {
            CargarPuertosDisponibles();
        }

        private void CargarPuertosDisponibles()
        {
            cmbPuertos.Items.Clear();
            string[] puertos = SerialPort.GetPortNames();
            if (puertos.Length == 0)
            {
                MessageBox.Show("No se detectaron puertos COM disponibles.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Array.Sort(puertos);
            cmbPuertos.Items.AddRange(puertos);
            cmbPuertos.SelectedIndex = 0;
        }

        private async void cmdDetectar_Click(object sender, EventArgs e)
        {
            if (cmbPuertos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un puerto COM para probar.");
                return;
            }

            string portName = cmbPuertos.SelectedItem.ToString();
            lstResultados.Items.Clear();
            lstResultados.Items.Add($"Iniciando detección automática en {portName}...");
            await Task.Run(() => AutoDetectSerialConfig(portName));
        }

        private void LogToUI(string text)
        {
            if (lstResultados.InvokeRequired)
            {
                lstResultados.Invoke(new Action(() =>
                {
                    lstResultados.Items.Add(text);
                    lstResultados.TopIndex = lstResultados.Items.Count - 1;
                }));
            }
            else
            {
                lstResultados.Items.Add(text);
                lstResultados.TopIndex = lstResultados.Items.Count - 1;
            }
        }

        private void AutoDetectSerialConfig(string portName)
        {
            int[] baudRates = { 9600, 4800, 2400, 1200 };
            int[] dataBits = { 7, 8 };
            Parity[] parities = { Parity.None, Parity.Even, Parity.Odd };
            StopBits[] stopBits = { StopBits.One, StopBits.Two };
            Handshake[] handshakes = { Handshake.None, Handshake.RequestToSend };

            foreach (int baud in baudRates)
            {
                foreach (int bits in dataBits)
                {
                    foreach (Parity parity in parities)
                    {
                        foreach (StopBits stop in stopBits)
                        {
                            foreach (Handshake handshake in handshakes)
                            {
                                using (SerialPort port = new SerialPort())
                                {
                                    try
                                    {
                                        port.PortName = portName;
                                        port.BaudRate = baud;
                                        port.DataBits = bits;
                                        port.Parity = parity;
                                        port.StopBits = stop;
                                        port.Handshake = handshake;
                                        port.Encoding = Encoding.ASCII;
                                        port.NewLine = "\r\n";
                                        port.ReadTimeout = 800;


                                        LogToUI($"🔍 Probando: {baud},{bits},{parity},{stop},{handshake}");

                                        port.Open();
                                        Thread.Sleep(400);

                                        string data = "";
                                        for (int i = 0; i < 3; i++)
                                        {
                                            try
                                            {
                                                data += port.ReadExisting();
                                                Thread.Sleep(200);
                                            }
                                            catch (TimeoutException) { }
                                        }

                                        port.Close();

                                        string muestra = data.Replace("\r", "").Replace("\n", "");

                                        if (muestra.Contains("*") && muestra.Any(char.IsDigit))
                                        {
                                            // ✅ Lectura correcta detectada
                                            this.Invoke(new Action(() =>
                                            {
                                                //txtPortName.Text = port.PortName;
                                                txtBaudRate.Text = port.BaudRate.ToString();
                                                txtDataBits.Text = port.DataBits.ToString();
                                                txtParity.Text = port.Parity.ToString();
                                                txtStopBits.Text = port.StopBits.ToString();
                                                txtHandshake.Text = port.Handshake.ToString();
                                                txtEncoding.Text = port.Encoding.EncodingName;
                                                txtNewLine.Text = BitConverter.ToString(Encoding.ASCII.GetBytes(port.NewLine));
                                                txtReadTimeout.Text = port.ReadTimeout.ToString();
                                            }));

                                            LogToUI($"✅ Correcto: {baud},{bits},{parity},{stop},{handshake}");

                                            MessageBox.Show(
                                                "Configuración correcta detectada y cargada en los campos.",
                                                "Éxito",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);

                                            return;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogToUI($"⚠️ Error: {ex.Message}");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            LogToUI("❌ No se encontró una configuración válida.");
        }
        /*
                private void cmdGuardarConfig_Click(object sender, EventArgs e)
                {
                    try
                    {
                        string fileName = "configuracion_balanza.txt";
                        using (StreamWriter sw = new StreamWriter(fileName, false))
                        {
                            sw.WriteLine($"PortName={cmbPuertos.Text}");
                            sw.WriteLine($"BaudRate={txtBaudRate.Text}");
                            sw.WriteLine($"DataBits={txtDataBits.Text}");
                            sw.WriteLine($"Parity={txtParity.Text}");
                            sw.WriteLine($"StopBits={txtStopBits.Text}");
                            sw.WriteLine($"Handshake={txtHandshake.Text}");
                            sw.WriteLine($"Encoding={txtEncoding.Text}");
                            sw.WriteLine($"NewLine={txtNewLine.Text}");
                            sw.WriteLine($"ReadTimeout={txtReadTimeout.Text}");
                        }

                        MessageBox.Show($"Configuración guardada correctamente en {Path.GetFullPath(fileName)}",
                            "Configuración guardada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la configuración: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                */
        private void cmdGuardarConfig_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el archivo de configuración
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Actualizar o agregar las claves
                SetAppSetting(config, "serialPortName", cmbPuertos.Text);
                SetAppSetting(config, "serialPortBaudios", txtBaudRate.Text);
                SetAppSetting(config, "serialPortBitsDatos", txtDataBits.Text);

                // Parity (en valor numérico)
                int parityValue = (int)Enum.Parse(typeof(Parity), txtParity.Text);
                SetAppSetting(config, "serialPortParity", parityValue.ToString());

                // StopBits (en valor numérico)
                int stopBitsValue = (int)Enum.Parse(typeof(StopBits), txtStopBits.Text);
                SetAppSetting(config, "serialPortBitsStopBits", stopBitsValue.ToString());

                SetAppSetting(config, "serialPortHandshake", txtHandshake.Text);
                SetAppSetting(config, "serialPortEncoding", txtEncoding.Text);
                SetAppSetting(config, "serialPortNewLine", txtNewLine.Text);
                SetAppSetting(config, "serialPortReadTimeout", txtReadTimeout.Text);

                // Guardar cambios
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Configuración guardada correctamente en App.config.",
                    "Configuración guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la configuración: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Método auxiliar
        private void SetAppSetting(Configuration config, string key, string value)
        {
            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 1. Leer valores desde App.config
                string portName = ConfigurationManager.AppSettings["serialPortName"];
                int baudRate = int.Parse(ConfigurationManager.AppSettings["serialPortBaudios"]);
                int dataBits = int.Parse(ConfigurationManager.AppSettings["serialPortBitsDatos"]);
                Parity parity = (Parity)int.Parse(ConfigurationManager.AppSettings["serialPortParity"]);
                StopBits stopBits = (StopBits)int.Parse(ConfigurationManager.AppSettings["serialPortBitsStopBits"]);
                Handshake handshake = (Handshake)Enum.Parse(typeof(Handshake), ConfigurationManager.AppSettings["serialPortHandshake"]);
                string encodingName = ConfigurationManager.AppSettings["serialPortEncoding"];
                string newLineHex = ConfigurationManager.AppSettings["serialPortNewLine"];
                int readTimeout = int.Parse(ConfigurationManager.AppSettings["serialPortReadTimeout"]);

                // 🔹 2. Mostrar los valores en los TextBox (por si querés verlos)
                //txtPortName.Text = portName;
                txtBaudRate.Text = baudRate.ToString();
                txtDataBits.Text = dataBits.ToString();
                txtParity.Text = parity.ToString();
                txtStopBits.Text = stopBits.ToString();
                txtHandshake.Text = handshake.ToString();
                txtEncoding.Text = encodingName;
                txtNewLine.Text = newLineHex;
                txtReadTimeout.Text = readTimeout.ToString();

                // 🔹 3. Crear y configurar el puerto serie
                serialPort = new SerialPort
                {
                    PortName = portName,
                    BaudRate = baudRate,
                    DataBits = dataBits,
                    Parity = parity,
                    StopBits = stopBits,
                    Handshake = handshake,
                    Encoding = Encoding.GetEncoding(encodingName),
                    ReadTimeout = readTimeout,
                    NewLine = HexToAscii(newLineHex)
                };


            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error Configurando el Puerto. Error:{0},{1}", Environment.NewLine, ex.Message)
                    , "Comfiguracion del Puerto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            try
            {

                // 🔹 4. Abrir el puerto
                ComenzarLectura();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al Abrier el puerto. Error:{0},{1}", Environment.NewLine, ex.Message)
                    , "Iniciando Comunicacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            IniciarCampos();
        
        }
        private void ComenzarLectura()
        {
            serialPort.Open();
            continuarLeyendo = true;
            Task.Run(() => leerDatosBalanzaAsync());

        }
        private void IniciarCampos()
        {
            cmdStop.Enabled = true;
            cmdStart.Enabled = false;

            txtPeso.Text = "";
            txtTara.Text = "";
            txtPesoTotal.Text = "";
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            continuarLeyendo = false;
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
            CerrarPrueto();

        }
        private void CerrarPrueto()
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar el puerto: " + ex.Message);
            }
        }
        private async Task leerDatosBalanzaAsync()
        {
            char STX = (char)2;   // Inicio de texto
            char CR = (char)13;   // Carriage Return (fin de mensaje)

            string buffer = "";
            string mensaje = "";
            string peso = "";
            string tara = "";
            string Total = "";

            while (continuarLeyendo)
            {
                try
                {
                    int byteLeido = serialPort.ReadByte(); // lectura bloqueante
                    if (byteLeido == -1) continue;

                    char c = (char)byteLeido;

                    if (c == STX)
                    {
                        // Nuevo mensaje
                        mensaje = "";
                        mensaje += c;
                    }
                    else if (c == CR)
                    {
                        // Fin de mensaje
                        LogDatosRecividos("Mensaje recibido: " + mensaje);
                        ObtenerCodigosAscii(mensaje);

                        // Ejemplo: *0 000006000000
                        if (mensaje.Length >= 14)
                        {
                            try
                            {
                                peso = mensaje.Substring(4, 6);
                                tara = mensaje.Substring(10, 6);
                                try
                                {
                                    Total = (long.Parse(peso) + long.Parse(tara)).ToString();
                                }
                                catch
                                {
                                    Total = "0";
                                }
                                this.Invoke((Action)(() =>
                                {
                                    txtPeso.Text = peso;
                                    txtTara.Text = tara;
                                    txtPesoTotal.Text = Total;

                                }));
                                if (lstLectura.InvokeRequired)
                                {
                                    lstLectura.Invoke(new Action(() =>
                                    {
                                        lstLectura.Items.Add("   " + peso + "   -     " + tara + "    -   " + Total);
                                        lstLectura.TopIndex = lstResultados.Items.Count - 1;
                                    }));
                                }
                                else
                                {
                                    lstLectura.Items.Add(peso + " - " + tara);
                                    lstLectura.TopIndex = lstResultados.Items.Count - 1;
                                }
                                LogDatosRecividos($"Peso:{peso} Tara:{tara}");
                            }
                            catch (Exception ex)
                            {
                                LogDatosRecividos("Error parseando mensaje: " + ex.Message);
                            }
                        }

                        mensaje = "";
                    }
                    else
                    {
                        mensaje += c;
                    }
                }
                catch (TimeoutException)
                {
                    // no hay datos, continuar leyendo
                }
                catch (Exception ex)
                {
                    if (continuarLeyendo)
                    {
                        LogDatosRecividos("Error al leer: " + ex.Message);
                    }
                }
            }
        }
        private void ObtenerCodigosAscii(string cadena)
        {
            char[] caracteres = cadena.ToCharArray();
            int[] codigosAscii = new int[caracteres.Length];
            string srtcadena;

            for (int i = 0; i < caracteres.Length; i++)
            {
                codigosAscii[i] = Convert.ToInt32(caracteres[i]);
                srtcadena = "caracteres:" + caracteres[i] + "-codigosAscii:" + codigosAscii[i].ToString();
                LogDatosRecividos(srtcadena);

            }

        }
        private void LogDatosRecividos(string strDatos)
        {
            try
            {
             //   if (ClsGlobalVariables.strConfigLogDataReceiving == "S")
             //   {
                    if (logFile == null)
                    {
                        // Obtener la fecha y hora actual
                        DateTime now = DateTime.Now;
                        string strArchivo = $"{now:yyyyMMdd_HHmmss}";
                        nombreArchivo = $"{strArchivo}.txt";

                        // Abre el archivo de texto para registro continuo de datos
                        logFile = new StreamWriter(nombreArchivo, true); // 'true' para añadir datos al final del archivo existente
                        logFile.AutoFlush = true; // Asegura que los datos se escriban inmediatamente en el archivo
                    }

                    logFile.WriteLine(strDatos);

               // }


            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurre un error al escribir en el archivo
                Console.WriteLine("Error al escribir en el archivo de log: " + ex.Message);
            }
        }
        private string HexToAscii(string hexString)
        {
            try
            {
                string[] bytes = hexString.Split('-');
                byte[] byteArray = new byte[bytes.Length];
                for (int i = 0; i < bytes.Length; i++)
                {
                    byteArray[i] = Convert.ToByte(bytes[i], 16);
                }
                return Encoding.ASCII.GetString(byteArray);
            }
            catch
            {
                // Valor por defecto si hay error
                return "\r\n";
            }
        }

        private void lstResultados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    /*


    <appSettings>
      <!-- Puerto serie físico o virtual (por ejemplo COM1, COM2, COM3, etc.) -->
      <add key="serialPortName" value="COM1" />

      <!-- Velocidad de transmisión (baudios): valores típicos = 1200, 2400, 4800, 9600 -->
      <add key="serialPortBaudios" value="9600" />

      <!-- Bits de datos: la balanza W180-T usa 7 bits -->
      <add key="serialPortBitsDatos" value="7" />

      <!-- Paridad: valores posibles según System.IO.Ports.Parity
             0 = None   → Sin paridad
             1 = Odd    → Impar
             2 = Even   → Par
             3 = Mark   → Paridad fija 1
             4 = Space  → Paridad fija 0 -->
      <add key="serialPortParity" value="2" />

      <!-- Bits de stop: valores posibles según System.IO.Ports.StopBits
             0 = None   → No se usa (raro)
             1 = One    → 1 bit de parada
             2 = Two    → 2 bits de parada
             3 = OnePointFive → 1.5 bits (algunos dispositivos antiguos) -->
      <add key="serialPortBitsStopBits" value="0" />

      <!-- Control de flujo (Handshake): valores posibles según System.IO.Ports.Handshake
             None          → Sin control de flujo
             XOnXOff       → Control por software
             RequestToSend → Control por hardware (RTS/CTS)
             RequestToSendXOnXOff → Combinado -->
      <add key="serialPortHandshake" value="None" />

      <!-- Codificación de texto (Encoding):
             US-ASCII → estándar de la mayoría de las balanzas
             UTF-8, Unicode, ISO-8859-1 → alternativos si aparecen caracteres raros -->
      <add key="serialPortEncoding" value="US-ASCII" />

      <!-- Secuencia de fin de línea (NewLine):
             0D-0A → CR LF (retorno de carro + salto de línea)
             0D    → solo CR
             0A    → solo LF -->
      <add key="serialPortNewLine" value="0D-0A" />

      <!-- Tiempo máximo de espera al leer (en milisegundos) -->
      <add key="serialPortReadTimeout" value="800" />
  </appSettings>
     */
}