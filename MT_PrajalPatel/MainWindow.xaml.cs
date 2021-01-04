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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MT_PrajalPatel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnViewPlayers_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow p = new PlayerWindow();
            p.Title = "Player Page";
            p.ShowDialog();
        }



        private void btnViewCoaches_Click(object sender, RoutedEventArgs e)
        {
            CoachWindow c = new CoachWindow();
            c.Title = "Coach Page";
            c.ShowDialog();
        }

        private void btnViewManagers_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow m = new ManagerWindow();
            m.Title = " Manager Page";
            m.ShowDialog();
        }



        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit from Main Page", "Exit Message",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void menuAboutme_Click(object sender, RoutedEventArgs e)
        {
            AboutmeWindow m = new AboutmeWindow();
            m.Title = "About Me";
            m.ShowDialog();
        }
    }
}
