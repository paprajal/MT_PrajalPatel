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
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        
        private List<Player> _players;
        public PlayerWindow()
        {
            InitializeComponent();

            _players = new List<Player>()
            {
                new Player(0, "Mark", 10, 7, 2, 70),
                new Player(1, "Mark", 10, 7, 2, 70),
                new Player(2, "Anna", 10, 7, 2, 70),
                new Player(3, "Sally", 10, 7, 2, 70),
                new Player(4, "David", 10, 7, 2, 70)
            };
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            var names = from emp in _players
                        select emp.Name;

            lstPlayer.ItemsSource = names;
        }

        private void lstPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstPlayer.SelectedIndex;

           
            var selectedEmp = (from emp in _players
                               where emp.Id == index
                               select emp).FirstOrDefault();

            if (selectedEmp != null)
            {
                tbName.Text = selectedEmp.Name;
                tbMatchesPlayed.Text = selectedEmp.MatchesPlayed.ToString();
                tbWon.Text = selectedEmp.Won.ToString();
                tbLost.Text = selectedEmp.Lost.ToString();
                tbGoalsScored.Text = selectedEmp.GoalsScored.ToString();

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           

           

            var data = from play in _players
                       where (tbName.Text == play.Name && int.Parse(tbMatchesPlayed.Text) == play.MatchesPlayed && int.Parse(tbWon.Text) == play.Won && int.Parse(tbLost.Text) == play.Lost && 
                       int.Parse(tbGoalsScored.Text) == play.GoalsScored)
                       select play;


            MessageBoxResult msg = MessageBoxResult.Yes;

            if (data.Any())
            {
                 msg  = MessageBox.Show("Same Information You Still want to proceed ?", "Same Information found",
                       MessageBoxButton.YesNo, MessageBoxImage.Warning);

                


            }
            if (msg == MessageBoxResult.Yes)
            {

                Player emp = new Player(_players.Count, tbName.Text, int.Parse(tbMatchesPlayed.Text), int.Parse(tbWon.Text), int.Parse(tbLost.Text), int.Parse(tbGoalsScored.Text));
                _players.Add(emp);
                RefreshListBox();
                MessageBox.Show("Player is Added Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);


            }
           


            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)



        {
            

            var data = from play in _players
                       where (tbName.Text == play.Name && int.Parse(tbMatchesPlayed.Text) == play.MatchesPlayed && int.Parse(tbWon.Text) == play.Won && int.Parse(tbLost.Text) == play.Lost &&
                       int.Parse(tbGoalsScored.Text) == play.GoalsScored)
                       select play;

            MessageBoxResult msg = MessageBoxResult.Yes;

            if (data.Any())
            {
                msg = MessageBox.Show("Same Information You Still want to proceed ?", "Same Information found",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);




            }
            if (msg == MessageBoxResult.Yes)
            {

                int index = lstPlayer.SelectedIndex;

                Player emp = _players[index];
                emp.Name = tbName.Text;
                emp.MatchesPlayed = int.Parse(tbMatchesPlayed.Text);
                emp.Won = int.Parse(tbWon.Text);
                emp.Lost = int.Parse(tbLost.Text);
                emp.GoalsScored = int.Parse(tbGoalsScored.Text);
               

                RefreshListBox();
                

                MessageBox.Show("Player is Updated Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)

        {
            var data = from play in _players
                       where (tbName.Text == play.Name && int.Parse(tbMatchesPlayed.Text) == play.MatchesPlayed && int.Parse(tbWon.Text) == play.Won && int.Parse(tbLost.Text) == play.Lost &&
                       int.Parse(tbGoalsScored.Text) == play.GoalsScored)
                       select play;


            MessageBoxResult msg = MessageBoxResult.Yes;

            if (data.Any())
            {
                msg = MessageBox.Show("Are you sure you want to delete from list?", "Confirmation",
                      MessageBoxButton.YesNo, MessageBoxImage.Warning);




            }
            if (msg == MessageBoxResult.Yes)
            {


                int index = lstPlayer.SelectedIndex;
                _players.RemoveAt(index);


                for (int i = 0; i < _players.Count; i++)
                    _players[i].Id = i;

                RefreshListBox();
                MessageBox.Show("Player is Deleted Successfully!", "Confirmation Message", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (tbID.Text == "" || tbName.Text == "" || tbMatchesPlayed.Text == "" || tbWon.Text == "" || tbLost.Text == "" || tbGoalsScored.Text == "")
            {
                MessageBox.Show("Must add all data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            return valid;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit from Player Page", "Exit Message",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }



    }
}
    

