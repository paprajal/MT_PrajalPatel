using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Collections collections = new Collections();
        public LoginWindow()
        {

            InitializeComponent();
            collections.addUser("Prajal Patel", new Login( "Prajal Patel", "prajal@pa"));
            collections.addUser("Harsh Patel", new Login("Harsh Patel", "harsh@pa"));
            collections.addUser("Hansit Patel", new Login("Hansit Patel", "hansit@pa"));


            txtUser.Focus();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
           

            if (isValid == true)
            {
                var check = from user in collections.getUser()
                            where (user.Value.UserName == txtUser.Text) && (user.Value.Password == txtPass.Password)
                            select user;
                if (check.Any())
                {
                    MainWindow m = new MainWindow();
                    m.Title = "WelCome";
                    m.ShowDialog();



                }
                else
                {
                    MessageBox.Show("Incorrect inputs please Enter Valid inputs", "Login Failed",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        public bool userValidation(string username, string password)
        {
            List<Login> user = new List<Login>()
            {
                new Login("Prajal Patel", "prajal@pa"),
                new Login("Harsh Patel", "harsh@pa"),
                new Login("Hansit Patel", "hansit@pa")



            };
            Dictionary<string, string> usd = new Dictionary<string, string>();

            foreach (var x in user)
            {
                usd.Add(x.UserName, x.Password);
            }
            return usd.Any(input => input.Key == username && input.Value == password);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit from Application", "Exit Message",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
