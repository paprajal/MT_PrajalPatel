using System;
using System.Collections.Generic;
using System.Text;

namespace MT_PrajalPatel
{
    public class Player : Person
    {


        private int _won;
        private int _matchesPlayed;
        private int _lost;
        private int _goalsScored;
      

        public int MatchesPlayed
        {
            get { return _matchesPlayed; }
            set { _matchesPlayed = value; }
        }

        public int Won
        {
            get { return _won; }
            set { _won = value; }

        }

        public int Lost
        {
            get { return _lost; }
            set { _lost = value; }
        }

        
        public int GoalsScored
        {
            get { return _goalsScored; }
            set { _goalsScored = value; }
        }

        public Player(int id, string name, int matchesPlayed, int won, int lost, int goalsScored)
            :base(id, name)
        {
            MatchesPlayed = matchesPlayed;
            Won = won;
            Lost = lost;
            GoalsScored = goalsScored;


        }

    }
}
