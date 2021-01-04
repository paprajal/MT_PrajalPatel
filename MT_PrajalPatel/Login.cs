using System;
using System.Collections.Generic;
using System.Text;

namespace MT_PrajalPatel
{
    class Login
    {
        
        private string _UserName;
        private string _Password;
      

       
        public string UserName {     
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Password {
            get { return _Password; }
            set { _Password = value; }
        }
        

        public Login( string uName, string pword) 
        {
            
            UserName = uName;
            Password = pword;
            
        }

        public Login() { }

        Dictionary<string, Login> uk = new Dictionary<string, Login>();

        public void addUser(string username, Login userLogin)
        {
            uk.Add(username, userLogin);
        }

        public Dictionary<string, Login> getUser()
        {
            Dictionary<string, Login> usData= new Dictionary<string, Login>();
            foreach (var u in uk)
            {
                usData.Add(u.Key, u.Value);
            }
            return usData;
        }

        public void deleteUser(string username)
        {
            uk.Remove(username);
        }

    }
}



