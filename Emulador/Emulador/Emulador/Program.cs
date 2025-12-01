using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace Emulador
{
    internal class Program
    {
        /*
                static void Main(string[] args)
                {
                    SerialPort serialPort = new SerialPort("COM4", 9600, Parity.Even, 7, StopBits.Two);
                    serialPort.Open();
                    Random random = new Random();

                    while (true)
                    {
                        // Simular datos de la balanza
                        int pesoAleatorio = random.Next(1, 1000000);
                        string pesoEnviado = pesoAleatorio.ToString("D6");
                        //string data = "\u0002" + "A" + "B" + "C" + pesoEnviado + "000000" + " *******  Peso del Mensaje:" + pesoEnviado + "\r\n";
                        string data = "\u0002" + "A" + "B" + "C" + pesoEnviado + "000000" + "\r\n";
                        serialPort.WriteLine(data);

                        Console.WriteLine("Enviando: " + data );
                        Thread.Sleep(1000); // Esperar 1 segundo antes de enviar el siguiente dato
                    }
                }
        */

        /*static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort("COM4", 9600, Parity.Even, 7, StopBits.Two);
            serialPort.Open();
            Random random = new Random();

            while (true)
            {
                // Simular datos de la balanza
                int pesoAleatorio = random.Next(1, 1000000);
                string pesoEnviado = pesoAleatorio.ToString("D6");

                // Crear la cadena de datos
                string data = "\u0002" + "A" + "B" + "C" + pesoEnviado + "000000" + "\r\n";

                // Convertir la cadena a un arreglo de bytes
                byte[] bytesToSend = Encoding.ASCII.GetBytes(data);

                // Enviar los bytes a través del puerto serial
                serialPort.Write(bytesToSend, 0, bytesToSend.Length);

                Console.WriteLine("Enviando: " + BitConverter.ToString(bytesToSend));
                Thread.Sleep(1000); // Esperar 1 segundo antes de enviar el siguiente dato
            }
        }*/
        static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort("COM2", 9600, Parity.Even, 7, StopBits.Two);
            serialPort.Open();
            Random random = new Random();

            while (true)
            {
                // Simular datos de la balanza
                int pesoAleatorio = random.Next(1, 1000000);
               // string pesoEnviado = "006610";//pesoAleatorio.ToString("D6");
                string pesoEnviado = pesoAleatorio.ToString("D6");

                // Crear la cadena de datos
                //string data = "\u0002" + "*" + "B" + "C" + pesoEnviado + "000050" + "\r\n";

                
                string data = "\u0002" + "*" + "B" + "C" + pesoEnviado + "000000" + " *******  Peso del Mensaje:" + pesoEnviado + "\r\n";




                // Convertir la cadena a un arreglo de bytes
                byte[] bytesToSend = Encoding.ASCII.GetBytes(data);

                // Enviar los bytes a través del puerto serial
                serialPort.Write(bytesToSend, 0, bytesToSend.Length);

                Console.WriteLine("Enviando: " + BitConverter.ToString(bytesToSend));
                Thread.Sleep(1000); // Esperar 1 segundo antes de enviar el siguiente dato
            }
        }
    }
}
