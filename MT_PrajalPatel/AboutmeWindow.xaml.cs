using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MT_PrajalPatel
{
    /// <summary>
    /// Interaction logic for AboutmeWindow.xaml
    /// </summary>
    public partial class AboutmeWindow : Window
    {
        
        public AboutmeWindow()
        {
            InitializeComponent();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit from AboutMe Page", "Exit Message",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }


}
