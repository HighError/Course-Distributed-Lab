using System.Security.Cryptography;
using System.Text;

namespace GachiBlockchain
{
    public class Chain
    {
        public double amount;
        public string hash;
        public string prevhash;
        public int index;

        static public int count = 0;

        public void CreateBlock(double amount, string prevhash)
        {
            this.amount = amount;
            this.prevhash = prevhash;
            index = count++;
            hash = GetHash();

        }

        public string GetHash()
        {
            MD5 md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, amount.ToString() + prevhash + index.ToString());

        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
