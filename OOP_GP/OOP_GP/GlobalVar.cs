using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_GP
{
    public static class GlobalVar
    {
        static string language;
        public static string GlobalLang
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
            }
        }
        static string userID;
        public static string GlobalID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
    }
}
