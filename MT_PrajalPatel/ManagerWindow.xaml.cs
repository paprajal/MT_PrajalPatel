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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private List<Manager> _managers;
        public ManagerWindow()
        {
            InitializeComponent();

            _managers = new List<Manager>()
            {
                new Manager(0, "John", 12, 479.99, "Leader"),
                new Manager(1, "Mark", 5, 349.67, "Motivator"),
                new Manager(2, "Anna", 5, 349.67, "Motivator"),
                new Manager(3, "Sally", 5, 349.67, "Motivator"),
                new Manager(4, "David", 5, 349.67, "Motivator")
            };
        }


       
private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            var names = from emp in _managers
                        select emp.Name;

            lstManager.ItemsSource = names;
        }

        private void lstManager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstManager.SelectedIndex;

            
            var selectedEmp = (from emp in _managers
                               where emp.Id == index
                               select emp).FirstOrDefault();

            if (selectedEmp != null)
            {
                tbName.Text = selectedEmp.Name;
                tbPlayersRecruited.Text = selectedEmp.PlayersRecruited.ToString();
               tbAvailableBudget.Text = selectedEmp.AvailableBudget.ToString();
                tbStrength.Text = selectedEmp.Strength;
            }
        }
        

private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            var data = from play in _managers
                       where (tbName.Text == play.Name && int.Parse(tbPlayersRecruited.Text) == play.PlayersRecruited && double.Parse(tbAvailableBudget.Text) == play.AvailableBudget && tbStrength.Text == play.Strength)
                       select play;


            MessageBoxResult msg = MessageBoxResult.Yes;
            if (data.Any())
            {

                msg = MessageBox.Show("Same Information You Still want to proceed ?", "Same information found",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);


            }


            if (msg == MessageBoxResult.Yes)
            {
                Manager emp = new Manager(_managers.Count, tbName.Text, int.Parse(tbPlayersRecruited.Text), double.Parse(tbAvailableBudget.Text), tbStrength.Text);
                _managers.Add(emp);

                RefreshListBox();
                MessageBox.Show("Manager is Added Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            var data = from play in _managers
                       where (tbName.Text == play.Name && int.Parse(tbPlayersRecruited.Text) == play.PlayersRecruited && double.Parse(tbAvailableBudget.Text) == play.AvailableBudget && tbStrength.Text == play.Strength)
                       select play;


            MessageBoxResult msg = MessageBoxResult.Yes;
            if (data.Any())
            {

                msg = MessageBox.Show("Same Information You Still want to proceed ?", "Same Information found",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);


            }


            if (msg == MessageBoxResult.Yes)
            {


                int index = lstManager.SelectedIndex;

                Manager emp = _managers[index];
                emp.Name = tbName.Text;
                emp.PlayersRecruited = int.Parse(tbPlayersRecruited.Text);
                emp.AvailableBudget = double.Parse(tbAvailableBudget.Text);
                emp.Strength = tbStrength.Text;

                RefreshListBox();
                MessageBox.Show("Manager is Updated Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var data = from play in _managers
                       where (tbName.Text == play.Name && int.Parse(tbPlayersRecruited.Text) == play.PlayersRecruited && double.Parse(tbAvailableBudget.Text) == play.AvailableBudget && tbStrength.Text == play.Strength)
                       select play;


            MessageBoxResult msg = MessageBoxResult.Yes;
            if (data.Any())
            {

                msg = MessageBox.Show("Are you sure you want to delete from list?", "Confirmation",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);


            }


            if (msg == MessageBoxResult.Yes)
            {
                int index = lstManager.SelectedIndex;
                _managers.RemoveAt(index);


                for (int i = 0; i < _managers.Count; i++)
                    _managers[i].Id = i;

                RefreshListBox();
                MessageBox.Show("Manager is Deleted Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void menuAboutme_Click(object sender, RoutedEventArgs e)
        {
            AboutmeWindow m = new AboutmeWindow();
            m.Title = "About Me";
            m.ShowDialog();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validationData()
        {
            bool valid = true;
            if (tbID.Text == "" || tbName.Text == "" || tbPlayersRecruited.Text == "" || tbAvailableBudget.Text == "" || tbStrength.Text == "")
            {
                MessageBox.Show("Must input all data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            return valid;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit from Manager Page", "Exit Message",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }


    }
}
