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
        public static string GlobalValue
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
        public static string userID;
        public static string GlobalInt
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
