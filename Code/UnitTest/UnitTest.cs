using GachiBlockchain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void VerificationOk()
        {
            Random random = new Random();
            List<Chain> blockchain = new List<Chain>();

            //Create 10 blocks
            for (int i = 0; i < 10; i++)
            {
                Chain chain = new Chain();
                chain.CreateBlock(random.NextDouble(), blockchain.Count < 1 ? "" : blockchain.Last().hash);
                blockchain.Add(chain);
            }

            Assert.AreEqual(GachiBlockchain.Program.VerificationBC(blockchain), true);
        }

        [TestMethod]
        public void VerificationError1()
        {
            Random random = new Random();
            List<Chain> blockchain = new List<Chain>();

            //Create 10 blocks
            for (int i = 0; i < 10; i++)
            {
                Chain chain = new Chain();
                chain.CreateBlock(random.NextDouble(), blockchain.Count < 1 ? "" : blockchain.Last().hash);
                blockchain.Add(chain);
            }

            // Change amount in 2-nd block
            blockchain[1].amount = 0.3;

            Assert.AreEqual(GachiBlockchain.Program.VerificationBC(blockchain), false);
        }

        [TestMethod]
        public void VerificationError2()
        {
            Random random = new Random();
            List<Chain> blockchain = new List<Chain>();

            //Create 10 blocks
            for (int i = 0; i < 10; i++)
            {
                Chain chain = new Chain();
                chain.CreateBlock(random.NextDouble(), blockchain.Count < 1 ? "" : blockchain.Last().hash);
                blockchain.Add(chain);
            }

            // Change amount in 2-nd block
            blockchain[1].amount = 0.3;
            // Regenerate new hash
            blockchain[1].hash = blockchain[1].GetHash();

            Assert.AreEqual(GachiBlockchain.Program.VerificationBC(blockchain), false);
        }
    }
}
