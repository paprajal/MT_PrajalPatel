using System;
using System.Collections.Generic;
using System.Text;

namespace MT_PrajalPatel
{
    public class Manager : Person
    {
        private int _playersRecruited;
        private double _availableBudget ;
        private string _strength;
       

        public int PlayersRecruited
        {
            get { return _playersRecruited; }
            set { _playersRecruited = value; }
        }

        public double AvailableBudget 
        {
            get { return _availableBudget; }
            set { _availableBudget = value; }

        }

        public string Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        

        public Manager(int id, string name, int playersRecruited, double availableBudget, string strength) : base(id, name)
        {
            PlayersRecruited = playersRecruited;
            AvailableBudget = availableBudget;
            Strength = strength;
            


        }
    }
}
