using Klient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Menu
{
    public partial class NickNameLobby : Window
    {
        public NickNameLobby()
        {
            InitializeComponent();
        }

        private void NickNameSpace_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NickNameSpace.Text))
            {
                string nick = NickNameSpace.Text;
                ClientWindow clientWindow = new ClientWindow(nick);
                clientWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter your nickname.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
