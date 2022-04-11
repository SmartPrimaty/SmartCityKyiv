using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartCityKyiv.Services
{
    public class Utilities
    {
        public static string CreateHashString(string source)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            byte[] targerBytes = sha256.ComputeHash(sourceBytes);
            string target = Encoding.UTF8.GetString(targerBytes);
            return target;
        }
    }
}
