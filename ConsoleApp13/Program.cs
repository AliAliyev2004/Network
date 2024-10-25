using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UdpServer
{
    static void Main()
    {
        // Define the port to listen on
        int port = 11000;

        // Create a UdpClient to listen for incoming messages
        using (UdpClient udpServer = new UdpClient(port))
        {
            Console.WriteLine("UDP Server started. Waiting for messages...");

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);

            // Continuously listen for incoming messages
            while (true)
            {
                // Receive a message from any client
                byte[] receivedBytes = udpServer.Receive(ref remoteEndPoint);
                string receivedMessage = Encoding.UTF8.GetString(receivedBytes);

                Console.WriteLine($"Message received: {receivedMessage} from {remoteEndPoint}");

                // Optionally, send a response back to the client
                byte[] responseBytes = Encoding.UTF8.GetBytes("Message received.");
                udpServer.Send(responseBytes, responseBytes.Length, remoteEndPoint);
            }
        }
    }
}
