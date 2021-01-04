using System;
using System.Collections.Generic;
using System.Text;

namespace MT_PrajalPatel
{
    public class Coach : Person
    {
        private int _numberOfTeamsCoached;
        private int _playersTrained;
        private double _winPercentage;
        private int _yearsOfExperience;


        public int NumberOfTeamsCoached
        {
            get { return _numberOfTeamsCoached; }
            set { _numberOfTeamsCoached = value; }
        }

        public int PlayersTrained
        {
            get { return _playersTrained; }
            set { _playersTrained = value; }

        }

        public double WinPercentage
        {
            get { return _winPercentage; }
            set { _winPercentage = value; }
        }

        public int YearsOfExperience
        {
            get { return _yearsOfExperience; }
            set { _yearsOfExperience = value; }
        }

        public Coach(int id, string name, int numberOfTeamsCoached, int playersTrained, double winPercentage, int yearsOfExperience)
            : base(id, name)
        {
            NumberOfTeamsCoached = numberOfTeamsCoached;
            PlayersTrained = playersTrained;
            WinPercentage = winPercentage;
            YearsOfExperience = yearsOfExperience;


        }

    }
}
