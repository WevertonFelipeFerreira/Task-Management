using System.Security.Cryptography;
using System.Text;

namespace Tasking.Management.CrossCutting.Utils
{
    public static class Encrypt
    {
        public static string Sha256(string input)
        {
            // Returns byte array
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
