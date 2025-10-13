using Microsoft.Win32;
using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PruebaLectura
{
    public partial class FormBalanza : Form
    {
        bool blnIncicioFormularioSinError = false;


        private SerialPort serialPort;
        //private StringBuilder receivedData = new StringBuilder();
        private delegate void DelegadoAcceso(string accion);
        string nombreArchivo;
        private StreamWriter logFile;

        string srtBuffer;

        long lngNroLinea = 0;

        bool continuarLeyendo = false;


        public FormBalanza()
        {
            InitializeComponent();
        }

        private void FormBalanza_Load(object sender, EventArgs e)
        {

            blnIncicioFormularioSinError = true;
        }


        private void FormBalanza_Shown(object sender, EventArgs e)
        {
            if (!blnIncicioFormularioSinError)
            {
                this.Dispose();
            }
        }
        private void IniciarCampos()
        {
            cmdStop.Enabled = true;
            cmdStart.Enabled = false;

            txtPeso.Text = "";
            txtTara.Text = "";
            txtPesoTotal.Text = "";
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            String serialPortName = txtPuertoSerie.Text;//< add key = "serialPortName" value = "COM2" />
            String serialPortBaudios = txtBaudios.Text; //< add key = "serialPortBaudios" value = "9600" />
            String serialPortBitsDatos = txtBitsDatos.Text;// < add key = "serialPortBitsDatos" value = "8" />
            String serialPortParity = txtSerialPortParity.Text; //< add key = "serialPortParity" value = "0" />
            String serialPortBitsStopBits = txtSerialPortBitsStopBits.Text; //< add key = "serialPortBitsStopBits" value = "1" />
            String xHandshake = txtHandshake.Text;
            ClsGlobalVariables.strConfigLogDataReceiving = "S";



            ClsGlobalVariables.strConfigSerialPortName = serialPortName;
            ClsGlobalVariables.strConfigSerialPortBaudios = serialPortBaudios;
            ClsGlobalVariables.strConfigSerialPortBitsDatos = serialPortBitsDatos;
            ClsGlobalVariables.strConfigSerialPortParity = serialPortParity;
            ClsGlobalVariables.strConfigserialPortBitsStopBits = serialPortBitsStopBits;

            ClsGlobalVariables.strHandshake = xHandshake;

            try
            {
                //; Configurar la velocidad de transmisión, paridad, bits de datos y bits de parada.ej:9600,E,7,2
                //Settings = 9600,E,7,2
             /*
                serialPort = new SerialPort();
                serialPort.PortName = ClsGlobalVariables.strConfigSerialPortName;
                serialPort.BaudRate = int.Parse(ClsGlobalVariables.strConfigSerialPortBaudios);
                serialPort.DataBits = int.Parse(ClsGlobalVariables.strConfigSerialPortBitsDatos);
                serialPort.Parity = (Parity)int.Parse(ClsGlobalVariables.strConfigSerialPortParity);
                serialPort.StopBits = (StopBits)int.Parse(ClsGlobalVariables.strConfigserialPortBitsStopBits);
                serialPort.Handshake = (Handshake)int.Parse(ClsGlobalVariables.strHandshake); 
                */
                /*
                serialPort = new SerialPort();
                serialPort.PortName = ClsGlobalVariables.strConfigSerialPortName;
                serialPort.BaudRate = 9600;              // o el que corresponda
                serialPort.DataBits = 7;                 // ⚠️ debe ser 7
                serialPort.Parity = Parity.Even;         // ⚠️ debe ser Even (par)
                serialPort.StopBits = StopBits.Two;      // ⚠️ debe ser 2
                serialPort.Handshake = Handshake.None;   // o Handshake.RequestToSend si realmente necesitás control de flujo HW
                serialPort.Encoding = Encoding.ASCII;    // para que no meta '?' por bytes fuera del rango ASCII
                serialPort.NewLine = "\r\n";             // CR+LF de fin de mensaje
                */

                serialPort = new SerialPort
                {
                    PortName = txtPuertoSerie.Text,   // ejemplo: COM6
                    BaudRate = 9600,
                    DataBits = 7,
                    Parity = Parity.Even,
                    StopBits = StopBits.Two,
                    Handshake = Handshake.None,
                    Encoding = Encoding.ASCII,
                    NewLine = "\r\n",
                    ReadTimeout = 500
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

        private void cmdStop_Click(object sender, EventArgs e)
        {
            continuarLeyendo = false;
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
            CerrarPrueto();


            //MessageBox.Show("Lectura del puerto terminada.");
            // Cierra el archivo de texto cuando la aplicación se cierre

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
        private void ComenzarLectura()
        {
            serialPort.Open();
            continuarLeyendo = true;
                Task.Run(() => leerDatosBalanzaAsync());
                //await leerDatosBalanzaAsync();
        }
        private void LogDatosRecividos(string strDatos)
        {
            try
            {
                if (ClsGlobalVariables.strConfigLogDataReceiving == "S")
                {
                    if (logFile == null)
                    {
                        // Obtener la fecha y hora actual
                        DateTime now = DateTime.Now;
                        string strArchivo = $"{now:yyyyMMdd_HHmmss}";
                        nombreArchivo = $"{strArchivo}_ConModificaciones.txt";

                        // Abre el archivo de texto para registro continuo de datos
                        logFile = new StreamWriter(nombreArchivo, true); // 'true' para añadir datos al final del archivo existente
                        logFile.AutoFlush = true; // Asegura que los datos se escriban inmediatamente en el archivo
                    }

                    logFile.WriteLine(strDatos);

                }


            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurre un error al escribir en el archivo
                Console.WriteLine("Error al escribir en el archivo de log: " + ex.Message);
            }
        }

        /**************************************************Lectura Asincrona ********************************/
        /*
                private async Task leerDatosBalanzaAsync()
                {                    // Definir el carácter STX usando su valor ASCII
                    char stx = (char)2;
                    // Definir el carácter Chr(13) usando su valor ASCII
                    char chr13 = (char)13;
                    string strMensajeCompleto = "";
                    string strPeso = "";
                    string strTara = "";
                    string strTmpLog = "";
                    string strMensaje = "";
                    this.srtBuffer = "";

                    while (continuarLeyendo)
                    {
                        try
                        {
                            int intStxPosIni;
                            int intPosFinMsj;
                            // Leer datos disponibles en el buffer de entrada
                            strMensaje = serialPort.ReadLine();
                            LogDatosRecividos("NroLinea:" + lngNroLinea.ToString() + "-receivedData:" + strMensaje);

                            ObtenerCodigosAscii(strMensaje);

                            // ' guardo los datos recividos en el buffer
                            this.srtBuffer = this.srtBuffer + strMensaje;
                            // Escribe los datos recibidos en el archivo de texto
                            LogDatosRecividos("NroLinea:" + lngNroLinea.ToString() + "-srtBuffer:" + srtBuffer);

                            //' Buscar el inicio de un mensaje válido,dato comienza con <STX>
                            //' El carácter \u0002 es un carácter de control en la tabla ASCII y se denomina "Start of Text" (STX).
                            //' ASCII del carácter \u0002 es 2
                            //' Verificar si el dato comienza con <STX> == Chr(2)
                            //'If Asc(Mid(incomingData, 1, 1)) = &H2 Then

                            intStxPosIni = srtBuffer.IndexOf(stx);
                            if (intStxPosIni > -1)
                            {
                                intPosFinMsj = srtBuffer.IndexOf(chr13, intStxPosIni);
                                if (intPosFinMsj > -1)
                                {
                                    try
                                    {
                                        strMensajeCompleto = this.srtBuffer.Substring(intStxPosIni, intPosFinMsj - intStxPosIni);
                                        //"\u0002\u0002\u0002*BC123456ABCDEF"
                                        // Encuentra la posición del último '\u0002'
                                        int lastIndex = strMensajeCompleto.LastIndexOf(stx);
                                        strMensajeCompleto = strMensajeCompleto.Substring(lastIndex);

                                        strPeso = strMensajeCompleto.Substring(4, 6);
                                        strTara = strMensajeCompleto.Substring(10, 6);
                                        this.Invoke((Action)(() =>
                                        {
                                            txtPeso.Text = strPeso;
                                            txtTara.Text = strTara;
                                            try
                                            {
                                                txtPesoTotal.Text = (long.Parse(strPeso.ToString()) + long.Parse(strTara.ToString())).ToString();
                                            }
                                            catch (Exception ex)
                                            {
                                                txtPesoTotal.Text = "0";
                                                //LogDatosRecividos("Error obteniendo pesos: " + ex.Message);
                                            }
                                            //txtPesoTk.Text = txtPesoTotal.Text;

                                        }));

                                    }
                                    catch (Exception ex)
                                    {
                                        LogDatosRecividos("Error obteniendo strMensajeCompleto: " + ex.Message);

                                    }
                                    // Aquí puedes procesar los datos recibidos según el protocolo de la balanza
                                    strTmpLog = "NroLinea:" + lngNroLinea.ToString()
                                                + "|strMensajeCompleto:" + strMensajeCompleto
                                                + "|strMensajeCompletoLength:" + strMensajeCompleto.Length.ToString()
                                                + "|strPeso:" + strPeso
                                                + "|strPesoLength:" + strPeso.Length.ToString()
                                                + "|strTara:" + strTara
                                                + "|strTaraLength:" + strTara.Length.ToString()
                                                + "|intStxPosIni:" + intStxPosIni.ToString()
                                                + "|intPosFinMsj:" + intPosFinMsj.ToString();

                                    //logFile.WriteLine
                                    LogDatosRecividos(strTmpLog);
                                    this.srtBuffer = "";
                                    ++this.lngNroLinea;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //ex.StackTrace.
                            if (continuarLeyendo)
                            {
                                Console.WriteLine("Error al leer datos: " + ex.Message);
                                MessageBox.Show("Error al leer datos, error: " + ex.Message, "Error leerDatosBalanzaAsync", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmdStop_Click(null, null);
                            }

                        }
                        Console.WriteLine("Leeee#########################################");

                    }
                    Console.WriteLine("termina********************************");
                }
        */

        private async Task leerDatosBalanzaAsync()
        {
            char STX = (char)2;   // Inicio de texto
            char CR = (char)13;   // Carriage Return (fin de mensaje)

            string buffer = "";
            string mensaje = "";
            string peso = "";
            string tara = "";

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

                        // Ejemplo: *0 000006000000
                        if (mensaje.Length >= 14)
                        {
                            try
                            {
                                peso = mensaje.Substring(4, 6);
                                tara = mensaje.Substring(10, 6);

                                this.Invoke((Action)(() =>
                                {
                                    txtPeso.Text = peso;
                                    txtTara.Text = tara;
                                    try
                                    {
                                        txtPesoTotal.Text = (long.Parse(peso) + long.Parse(tara)).ToString();
                                    }
                                    catch
                                    {
                                        txtPesoTotal.Text = "0";
                                    }
                                }));

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


        private void txtHandshake_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormBalanza_Load_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtBitsDatos_TextChanged(object sender, EventArgs e)
        {

        }
        /*
private void txtTara_TextChanged(object sender, EventArgs e)
{

}

private void label11_Click(object sender, EventArgs e)
{

}

private void txtPesoTotal_TextChanged(object sender, EventArgs e)
{

}

private void label2_Click(object sender, EventArgs e)
{

}

private void txtPeso_TextChanged(object sender, EventArgs e)
{

}

private void label1_Click(object sender, EventArgs e)
{

}

private void groupBox1_Enter(object sender, EventArgs e)
{

}



private void cmdGenerarTK_Click(object sender, EventArgs e)
{

if (txtCertificado.Text.Length == 0)
{
MessageBox.Show("El campo ''Certificado'' no puede estar sin datos", "Generarndo Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
txtCertificado.Focus();
return;
}
if (txtValidadCert.Text.Length == 0)
{
MessageBox.Show("El campo ''Validad Cert'' no puede estar sin datos", "Generarndo Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
txtValidadCert.Focus();
return;
}

if (txtNroPermisoEmbarque.Text.Length == 0)
{

MessageBox.Show("El campo ''Nro de Permiso de Embarque'' no puede estar sin datos", "Generarndo Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
txtNroPermisoEmbarque.Focus();
return;
}
if (txtIDContenedor.Text.Length == 0)
{
MessageBox.Show("El campo ''ID de Contenedor'' no puede estar sin datos", "Generarndo Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
txtIDContenedor.Focus();
return;
}
if ((txtIdentificadorBulto.Text.Length + txtIdentificadorBultoNro.Text.Length) == 0)
{
MessageBox.Show("El campo ''Identificador de Bulto'' no puede estar sin datos", "Generarndo Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
txtIdentificadorBulto.Focus();
return;
}
if (cmbMercaderia.Text.Length == 0)
{

MessageBox.Show("El campo ''Descripcion de la Mercaderia'' no puede estar sin datos", "Generarndo Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
cmbMercaderia.Focus();
return;
}

if (txtPeso.Text.Length == 0)
{
MessageBox.Show("El campo ''Peso (KG)'' no puede estar sin datos", "Generarndo Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
return;
}
cmdStop_Click(null, null);
try
{
// ClsTicketEntidad objTicket;
ClsGlobalVariables.objImpresion.FechaHora = DateTime.Now;
ClsGlobalVariables.objImpresion.NroPermEmbarque = txtNroPermisoEmbarque.Text;
ClsGlobalVariables.objImpresion.IdContenedor = txtIDContenedor.Text;
ClsGlobalVariables.objImpresion.IdentificadorBulto = txtIdentificadorBulto.Text + txtIdentificadorBultoNro.Text;
ClsGlobalVariables.objImpresion.IdMercaderia = cmbMercaderia.SelectedValue.ToString();
ClsGlobalVariables.objImpresion.Mercaderia = cmbMercaderia.Text;
ClsGlobalVariables.objImpresion.Peso = txtPeso.Text;


if (!ClsGlobalVariables.objImpresion.InsertarImpresion())
{
MessageBox.Show("No pudo guardar los datos del Ticket en la base de datos", "Guardando Ticket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
return;
}

//cargo el reporte 
FormTK objReporte = new FormTK();

objReporte.objTicket = ClsGlobalVariables.objImpresion;

objReporte.SetearReporte();

if (rdbGenerarArchivo.Checked)
{
objReporte.SaveReportToPdf2();
}
if (rdbGenerarArchivoVisualizar.Checked)
{
objReporte.SaveReportToPdf2();
objReporte.ShowDialog();

}
if (rdbVisualizar.Checked)
{
objReporte.ShowDialog();
}

if (!ClsGlobalVariables.objImpresion.ObtenerProximoNroTk())
{
return;
}

}
catch (Exception ex)
{

MessageBox.Show(String.Format("Error Generardo Ticket. Error:{0},{1}", Environment.NewLine, ex.Message), "Generando Impresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
finally
{
cmdStart_Click(null, null);
}

}

private void txtCertificado_TextChanged(object sender, EventArgs e)
{
////Convertir el texto a mayúsculas
txtCertificado.Text = txtCertificado.Text.ToUpper();
// Colocar el cursor al final del texto
txtCertificado.SelectionStart = txtCertificado.Text.Length;
}

private void txtValidadCert_TextChanged(object sender, EventArgs e)
{
////Convertir el texto a mayúsculas
txtValidadCert.Text = txtValidadCert.Text.ToUpper();
// Colocar el cursor al final del texto
txtValidadCert.SelectionStart = txtValidadCert.Text.Length;
}

private void txtNroPermisoEmbarque_TextChanged(object sender, EventArgs e)
{
////Convertir el texto a mayúsculas
txtNroPermisoEmbarque.Text = txtNroPermisoEmbarque.Text.ToUpper();
// Colocar el cursor al final del texto
txtNroPermisoEmbarque.SelectionStart = txtNroPermisoEmbarque.Text.Length;
}

private void txtIDContenedor_TextChanged(object sender, EventArgs e)
{
////Convertir el texto a mayúsculas
txtIDContenedor.Text = txtIDContenedor.Text.ToUpper();
// Colocar el cursor al final del texto
txtIDContenedor.SelectionStart = txtIDContenedor.Text.Length;
}

private void txtIdentificadorBulto_TextChanged(object sender, EventArgs e)
{
////Convertir el texto a mayúsculas
txtIdentificadorBulto.Text = txtIdentificadorBulto.Text.ToUpper();
// Colocar el cursor al final del texto
txtIdentificadorBulto.SelectionStart = txtIdentificadorBulto.Text.Length;
}

private void txtIdentificadorBultoNro_TextChanged(object sender, EventArgs e)
{
////Convertir el texto a mayúsculas
txtIdentificadorBultoNro.Text = txtIdentificadorBultoNro.Text.ToUpper();
// Colocar el cursor al final del texto
txtIdentificadorBultoNro.SelectionStart = txtIdentificadorBultoNro.Text.Length;
}

private void FormBalanza_FormClosing(object sender, FormClosingEventArgs e)
{
cmdStop_Click(null, null);
if (logFile != null)
{
logFile.Close();
}
}*/
    }
}
