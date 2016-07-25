using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace Spo.ToolsTestsBenchmarks.DebugAndTests.SerialPortCommunication
{
    public class SerialPortDebug
    {
        private const int DefaultBaudRate = 115200;
        static bool _continue;

        public static void Main()
        {
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            Console.InputEncoding = Encoding.Unicode;

            // Allow the user to set the appropriate properties.
            string portName = GetPortName();
            if (string.IsNullOrWhiteSpace(portName))
            {
                Console.WriteLine("App initialization failed.");
                Console.ReadKey();

                return;
            }

            using (var communicator = SerialPortCommunicator.OpenConnection(portName, GetPortBaudRate()))
            {
                _continue = true;
                Thread readThread = new Thread(c => Read(communicator));
                readThread.Start();
                while (_continue)
                {
                    var message = Console.ReadLine();
                    if (stringComparer.Equals("quit", message))
                    {
                        _continue = false;
                    }
                    else if (!string.IsNullOrWhiteSpace(message))
                    {
                        communicator.Write(message);
                    }
                }

                readThread.Join();
            }
        }

        public static void Read(SerialPortCommunicator communicator)
        {
            Console.WriteLine("Type QUIT to exit");
            while (_continue)
            {
                try
                {
                    string message = communicator.Read();
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        Console.Write(message);
                    }
                }
                catch (TimeoutException e) { }
            }
        }

        // Display Port values and prompt user to enter a port.
        private static string GetPortName()
        {
            string[] availablePorts = SerialPort.GetPortNames();
            if (availablePorts.Length == 0)
            {
                Console.WriteLine("No COM ports found. Check your harware settings.");

                return null;
            }

            string portName;
            string defaultPortName = availablePorts[0];
            Console.WriteLine("Available Ports:");
            foreach (string s in availablePorts)
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter COM port value (Default: {0}): ", defaultPortName);

            portName = Console.ReadLine();
            if (portName == "" || !(portName.ToLower()).StartsWith("com"))
            {
                portName = defaultPortName;
            }

            return portName;
        }
    
        // Display BaudRate values and prompt user to enter a value.
        private static int GetPortBaudRate()
        {
            Console.Write("Baud Rate(default:{0}): ", DefaultBaudRate);
            var inputBaudRate = Console.ReadLine();
            int baudRate;
            if (string.IsNullOrWhiteSpace(inputBaudRate) || !int.TryParse(inputBaudRate, out baudRate))
            {
                return DefaultBaudRate;
            }

            return baudRate;
        }
    }
}