using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Klient
{
    public partial class ClientWindow : Window
    {
        private TcpClient tcpClient;
        private NetworkStream clientStream;
        private string Nick { get; set; }
        private int counter_message = 0;

        public ClientWindow(string nick)
        {
            InitializeComponent();
            Nick = nick;
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string ipAddress = IPTextBox.Text;
            int port = Convert.ToInt32(PortTextBox.Text);
            try
            {
                tcpClient = new TcpClient(ipAddress, port);
                clientStream = tcpClient.GetStream();

                // Send nick to server
                byte[] nickBytes = Encoding.ASCII.GetBytes(Nick);
                clientStream.Write(nickBytes, 0, nickBytes.Length);
                clientStream.Flush();

                StatusLabel.Content = "Connected to server.";
                // Start a thread to receive messages from the server
                new System.Threading.Thread(ReceiveMessages).Start();
            }
            catch (Exception ex)
            {
                StatusLabel.Content = "Connection failed: " + ex.Message;
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientStream != null)
            {
                string message = MessageTextBox.Text;
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                clientStream.Write(messageBytes, 0, messageBytes.Length);
                clientStream.Flush();
                counter_message += 1;
                //SentTextBox.Text += "You: " + message + Environment.NewLine;
            }
        }

        private void ReceiveMessages()
        {
            while (true)
            {
                try
                {
                    byte[] messageBytes = new byte[4096];
                    int bytesRead = clientStream.Read(messageBytes, 0, messageBytes.Length);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.ASCII.GetString(messageBytes, 0, bytesRead);
                        Dispatcher.Invoke(() => {
                            ReceivedTextBox.Text += message + Environment.NewLine;
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error receiving message: " + ex.Message);
                    break;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int iloscWiadomosci = ReceivedTextBox.LineCount;
            BazaDanych bazaDanych = new BazaDanych();
            bazaDanych.InsertData(this.Nick, counter_message);

            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć chat?", "Zamknij okno", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        public void DisposeResources()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }
    }
}
