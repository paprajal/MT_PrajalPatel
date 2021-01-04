using System;
using System.Collections.Generic;
using System.Text;

namespace MT_PrajalPatel
{
    public abstract class Person
    {
        private int  _id;
        private string _name;

        public int Id 
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
