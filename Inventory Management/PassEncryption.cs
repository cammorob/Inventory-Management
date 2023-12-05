using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class PassEncryption
    {
        public static string HashPassword(string password)
        {
            SHA256 sha = SHA256.Create();



            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            var hashed_password = stringBuilder.ToString();


            return stringBuilder.ToString();




        }
        public static string DefaultHashPassword()
        {
            SHA256 sha = SHA256.Create();



            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("Password@123"));
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            var hashed_password = stringBuilder.ToString();


            return stringBuilder.ToString();




        }







    }
}
