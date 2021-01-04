using System;
using System.Collections.Generic;
using System.Text;

namespace MT_PrajalPatel
{
    class Collections
    {

        Dictionary<string, Login> uk = new Dictionary<string, Login>();
        public void addUser(string username, Login userlogin)
        {
            uk.Add(username, userlogin);
        }

        public Dictionary<string, Login> getUser()
        {
            Dictionary<string, Login> usData = new Dictionary<string, Login>();
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
