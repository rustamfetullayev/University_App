using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UniversityApp.Extension
{
    public static class Extensions
    {
        public static string HashPassword(string pass)
        {
            byte[] byteArray = Encoding.Unicode.GetBytes(pass);
            byte[] hashedArray = new SHA256Managed().ComputeHash(byteArray);
            string hashedPassword = Encoding.Unicode.GetString(hashedArray);

            return hashedPassword;
        }

        public static bool CheckPassword(string pass, string hashedPassword)
        {
            return HashPassword(pass) == hashedPassword;
        }
    }
}
