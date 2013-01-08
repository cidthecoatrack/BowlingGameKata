using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameKata.Tests
{
    [TestClass]
    public class BowlingGameTests
    {
        private BowlingGame game;
        
        [TestInitialize]
        public void TestInitialize()
        {
            game = new BowlingGame();
        }

        [TestMethod]
        public void GutterGame()
        {
            RollMany(0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void AllOnes()
        {
            RollMany(1, 20);
            Assert.AreEqual(20, game.GetScore());
        }

        private void RollMany(int pins, int Quantity)
        {
            for (int i = 0; i < Quantity; i++)
                game.Roll(pins);
        }

        [TestMethod]
        public void OneSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(0, 17);

            Assert.AreEqual(16, game.GetScore());
        }

        [TestMethod]
        public void OneStrike()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(3);
            RollMany(0, 16);

            Assert.AreEqual(24, game.GetScore());
        }

        [TestMethod]
        public void SpareInNonFirstFrame()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(3);
            game.Roll(5);
            game.Roll(5);
            game.Roll(1);
            RollMany(0, 13);

            Assert.AreEqual(36, game.GetScore());
        }

        [TestMethod]
        public void PerfectGame()
        {
            RollMany(10, 12);

            Assert.AreEqual(300, game.GetScore());
        }
    }
}
