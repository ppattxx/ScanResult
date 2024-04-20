using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrintGaransi
{
    public class TCPConnection
    {
        private TcpListener server;
        private int port;
        private Action<string> updateUiCallback;
        private Action<string> updateUiCallback2;

        public TCPConnection(int port, Action<string> updateUiCallback, Action<string> updateUiCallback2) // Added updateUiCallback2 as a parameter
        {
            this.port = port;
            this.updateUiCallback = updateUiCallback;
            this.updateUiCallback2 = updateUiCallback2; // Assigned updateUiCallback2
        }

        public async Task StartServerAsync()
        {
            // Scan all network adapters
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            IPAddress ipAddress = null;

            // Find the first operational Ethernet adapter
            foreach (NetworkInterface adapter in adapters)
            {
                // Check if the adapter is Ethernet and is operational
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet && adapter.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ipInfo in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddress = ipInfo.Address;
                            break;
                        }
                    }
                    if (ipAddress != null)
                    {
                        break;
                    }
                }
            }

            if (ipAddress == null)
            {
                updateUiCallback?.Invoke("No operational network adapter found.");
                return;
            }

            server = new TcpListener(ipAddress, port);
            server.Start();

            // Display the server's IP address and port
            //updateUiCallback?.Invoke($"Server started on IP: {ipAddress.ToString()}, Port: {port}");
            TcpClient client = await server.AcceptTcpClientAsync();
            await SendMessageToClientAsync(client, "Connected to server.");
            await HandleClientAsync(client);
        }

        private async Task SendMessageToClientAsync(TcpClient client, string message)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);
        }


        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                // Invoke the callback on the UI thread to update the UI

                string cleanedData = Regex.Replace(message, "<.*?>", "");
                splitData1(cleanedData);
                splitData2(cleanedData);
            }
            client.Close();
        }

        private void splitData1(string input)
        {
            string data1 = input.Substring(0, 2);
            updateUiCallback?.Invoke(data1);
        }

        private void splitData2(string input)
        {
            string data2 = input.Substring(2);
            updateUiCallback2?.Invoke(data2);
        }
    }
}
