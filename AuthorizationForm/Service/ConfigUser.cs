using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationForm
{
    internal class ConfigUser
    {
        public string? l_name;
        public string? p_name;

        public ConfigUser(string login, string password)
        {
            l_name = login;
            p_name = password;
        }
    }
}
