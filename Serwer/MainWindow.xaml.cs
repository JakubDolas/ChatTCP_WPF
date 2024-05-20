using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Serwer
{
    public partial class ServerWindow : Window
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private readonly Dictionary<Guid, TcpClient> clients = new Dictionary<Guid, TcpClient>();
        private readonly Dictionary<Guid, string> clientNicks = new Dictionary<Guid, string>();

        public ServerWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(IPTextBox.Text);
            int port = Convert.ToInt32(PortTextBox.Text);
            tcpListener = new TcpListener(ipAddress, port);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
            StatusLabel.Content = "Server started.";
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                clients[Guid.NewGuid()] = client;
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] nickBytes = new byte[4096];
            int nickBytesRead = clientStream.Read(nickBytes, 0, nickBytes.Length);
            string nick = Encoding.ASCII.GetString(nickBytes, 0, nickBytesRead);
            Guid clientId = Guid.NewGuid();
            clientNicks[clientId] = nick;

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                BroadcastMessage(message, bytesRead, clientId);
            }

            clients.Remove(clientId);
            clientNicks.Remove(clientId);
            tcpClient.Close();
        }

        private void BroadcastMessage(byte[] message, int bytesRead, Guid senderId)
        {
            string senderNick = clientNicks[senderId];
            foreach (var clientPair in clients)
            { 
                if (clientPair.Key != senderId)
                {
                    string messageToSend = $"{senderNick}: {Encoding.ASCII.GetString(message, 0, bytesRead)}";
                    clientPair.Value.GetStream().Write(Encoding.ASCII.GetBytes(messageToSend), 0, messageToSend.Length);
                    clientPair.Value.GetStream().Flush();
                }
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć serwer?", "Zamknij okno", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        public void DisposeResources()
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }

            if (listenThread != null && listenThread.IsAlive)
            {
                listenThread.Abort();
            }

            foreach (var clientPair in clients)
            {
                clientPair.Value.Close();
            }

            clients.Clear();
            clientNicks.Clear();
        }
    }
}
