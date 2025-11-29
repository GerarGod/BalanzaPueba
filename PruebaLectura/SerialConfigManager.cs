using System;
using System.Configuration;
using System.IO.Ports;
using System.Text;

namespace PruebaLectura
{
    public class SerialConfig
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }
        public string EncodingName { get; set; }
        public string NewLineHex { get; set; }
        public int ReadTimeout { get; set; }
    }

    public static class SerialConfigManager
    {
        // ---------------------------
        // Cargar configuración
        // ---------------------------
        public static SerialConfig Load()
        {
            return new SerialConfig
            {
                PortName = Get("serialPortName", "COM1"),
                BaudRate = GetInt("serialPortBaudios", 9600),
                DataBits = GetInt("serialPortBitsDatos", 8),
                Parity = (Parity)GetInt("serialPortParity", 0),
                StopBits = (StopBits)GetInt("serialPortBitsStopBits", 1),
                Handshake = (Handshake)Enum.Parse(typeof(Handshake), Get("serialPortHandshake", "None")),
                EncodingName = Get("serialPortEncoding", "ASCII"),
                NewLineHex = Get("serialPortNewLine", "0D-0A"),
                ReadTimeout = GetInt("serialPortReadTimeout", 800)
            };
        }

        // ---------------------------
        // Guardar configuración
        // ---------------------------
        public static void Save(SerialConfig cfg)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            Set(config, "serialPortName", cfg.PortName);
            Set(config, "serialPortBaudios", cfg.BaudRate.ToString());
            Set(config, "serialPortBitsDatos", cfg.DataBits.ToString());
            Set(config, "serialPortParity", ((int)cfg.Parity).ToString());
            Set(config, "serialPortBitsStopBits", ((int)cfg.StopBits).ToString());
            Set(config, "serialPortHandshake", cfg.Handshake.ToString());
            Set(config, "serialPortEncoding", cfg.EncodingName);
            Set(config, "serialPortNewLine", cfg.NewLineHex);
            Set(config, "serialPortReadTimeout", cfg.ReadTimeout.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        // ---------------------------
        // Helpers
        // ---------------------------
        private static string Get(string key, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        private static int GetInt(string key, int defaultValue)
        {
            if (int.TryParse(ConfigurationManager.AppSettings[key], out int result))
                return result;

            return defaultValue;
        }

        private static void Set(Configuration config, string key, string value)
        {
            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;
        }

        // Convierte Hex → ASCII (si necesitás)
        public static string HexToAscii(string hex)
        {
            try
            {
                string[] bytes = hex.Split('-');
                byte[] byteArray = new byte[bytes.Length];
                for (int i = 0; i < bytes.Length; i++)
                    byteArray[i] = Convert.ToByte(bytes[i], 16);

                return Encoding.ASCII.GetString(byteArray);
            }
            catch
            {
                return "\r\n"; // Default
            }
        }
    }
}
