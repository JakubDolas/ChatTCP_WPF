using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Klient;
using Serwer;

namespace Menu
{
    public partial class MainWindow : Window
    {
        private ClientWindow clientWindow;
        private ServerWindow serverWindow;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServerStartButton_Click(object sender, RoutedEventArgs e)
        {
            ServerWindow serverWindow = new ServerWindow();
            serverWindow.Show();
        }

        private void NickNameLobbyButton_Click(object sender, RoutedEventArgs e)
        {
            NickNameLobby lobby = new NickNameLobby();
            lobby.Show();
        }
        private void ShowDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseWindow dataBaseWindow = new DataBaseWindow();
            dataBaseWindow.Show();
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć aplikacje?", "Zamknij aplikacje", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Zwalnianie zasobów klienta
                if (clientWindow != null)
                {
                    clientWindow.DisposeResources();
                    serverWindow.DisposeResources();
                }

                Application.Current.Shutdown();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć aplikacje?", "Zamknij aplikacje", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}