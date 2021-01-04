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
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window
    {
        private List<Coach> _coaches;
        public CoachWindow()
        {
            InitializeComponent();

            _coaches = new List<Coach>()
            {
                new Coach(0, "John", 12, 19, 70.25, 5),
                new Coach(1, "Mark", 12, 19, 70.25, 5),
                new Coach(2, "Anna", 12, 19, 70.25, 5),
                new Coach(3, "Sally", 12, 19, 70.25, 5),
                new Coach(4, "David", 12, 19, 70.25, 5)
            };
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            var names = from emp in _coaches
                        select emp.Name;

            lstCoach.ItemsSource = names;
        }

        private void lstCoach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstCoach.SelectedIndex;

            
            var selectedEmp = (from emp in _coaches
                               where emp.Id == index
                               select emp).FirstOrDefault();

            if (selectedEmp != null)
            {
                tbName.Text = selectedEmp.Name;
                tbNumberOfTeamsCoached.Text = selectedEmp.NumberOfTeamsCoached.ToString();
                tbPlayersTrained.Text = selectedEmp.PlayersTrained.ToString();
                tbWinPercentage.Text = selectedEmp.WinPercentage.ToString();
                tbYearsOfExperience.Text = selectedEmp.YearsOfExperience.ToString();
            }
        }



   


private void btnAdd_Click(object sender, RoutedEventArgs e)
        {


            var data = from play in _coaches
                       where (tbName.Text == play.Name && int.Parse(tbNumberOfTeamsCoached.Text) == play.NumberOfTeamsCoached && int.Parse(tbPlayersTrained.Text) == play.PlayersTrained && double.Parse(tbWinPercentage.Text) == play.WinPercentage && int.Parse(tbYearsOfExperience.Text) == play.YearsOfExperience)
                       select play;

            MessageBoxResult msg = MessageBoxResult.Yes;

            if (data.Any())
            {
                msg = MessageBox.Show("Same Information You Still want to proceed ?", "Same Entry",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);




            }

            if (msg == MessageBoxResult.Yes)
            {



                Coach emp = new Coach(_coaches.Count, tbName.Text, int.Parse(tbNumberOfTeamsCoached.Text), int.Parse(tbPlayersTrained.Text), double.Parse(tbWinPercentage.Text), int.Parse(tbYearsOfExperience.Text));
                _coaches.Add(emp);

                RefreshListBox();
                MessageBox.Show("Coach is Added Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            var data = from play in _coaches
                       where (tbName.Text == play.Name && int.Parse(tbNumberOfTeamsCoached.Text) == play.NumberOfTeamsCoached && int.Parse(tbPlayersTrained.Text) == play.PlayersTrained && double.Parse(tbWinPercentage.Text) == play.WinPercentage && int.Parse(tbYearsOfExperience.Text) == play.YearsOfExperience)
                       select play;

            MessageBoxResult msg = MessageBoxResult.Yes;

            if (data.Any())
            {
                msg = MessageBox.Show("Same Information You Still want to proceed ?", "Same Information found",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);




            }

            if (msg == MessageBoxResult.Yes)
            {
                int index = lstCoach.SelectedIndex;

                Coach emp = _coaches[index];
                emp.Name = tbName.Text;
                emp.NumberOfTeamsCoached = int.Parse(tbNumberOfTeamsCoached.Text);
                emp.PlayersTrained = int.Parse(tbPlayersTrained.Text);
                emp.WinPercentage = double.Parse(tbWinPercentage.Text);
                emp.YearsOfExperience = int.Parse(tbYearsOfExperience.Text);

                RefreshListBox();
                MessageBox.Show("Coach is Updated Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var data = from play in _coaches
                       where (tbName.Text == play.Name && int.Parse(tbNumberOfTeamsCoached.Text) == play.NumberOfTeamsCoached && int.Parse(tbPlayersTrained.Text) == play.PlayersTrained && double.Parse(tbWinPercentage.Text) == play.WinPercentage && int.Parse(tbYearsOfExperience.Text) == play.YearsOfExperience)
                       select play;

            MessageBoxResult msg = MessageBoxResult.Yes;

            if (data.Any())
            {
                msg = MessageBox.Show("Are you sure you want to delete from list?", "Confirmation",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);


            }

            if (msg == MessageBoxResult.Yes)
            {
                int index = lstCoach.SelectedIndex;
                _coaches.RemoveAt(index);


                for (int i = 0; i < _coaches.Count; i++)
                    _coaches[i].Id = i;

                RefreshListBox();
                MessageBox.Show("Coach is Deleted Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (tbID.Text == "" || tbName.Text == "" || tbNumberOfTeamsCoached.Text == "" || tbPlayersTrained.Text == "" || tbWinPercentage.Text == "" || tbYearsOfExperience.Text == "")
            {
                MessageBox.Show("Must input all data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            return valid;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit from Coach Page", "Exit Message",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }



    }
}
    

        
    

