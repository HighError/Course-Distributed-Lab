using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GachiBlockchain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Chain> blockchain = new List<Chain>();

            for (int i = 0; i < 10; i++)
            {
                Chain chain = new Chain();
                chain.CreateBlock(random.NextDouble(), blockchain.Count < 1 ? "" : blockchain.Last().hash);
                blockchain.Add(chain);
            }

            if (VerificationBC(blockchain)) Console.WriteLine("Blockchain verified OK");
            else Console.WriteLine("Blockchain verified ERROR!");

            Console.ReadKey();
        }

        public static bool VerificationBC(List<Chain> blockchain)
        {
            for (int i = 1; i < blockchain.Count; i++)
            {
                if (blockchain[i].hash != blockchain[i].GetHash()) return false;
                if (blockchain[i].prevhash != blockchain[i - 1].hash) return false;
            }
            return true;
        }
    }
}
