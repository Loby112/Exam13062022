using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceResultLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceResultLib.Tests {
    [TestClass()]
    public class DiceResultTests {
        [TestMethod()]
        public void DiceResultTest(){
            DiceResult testDice = new DiceResult("Tobias", 6);
            DiceResult testDice2 = new DiceResult("Tre", 1);

            Assert.AreEqual("Tobias", testDice.PlayerName);
            Assert.AreEqual("Tre", testDice2.PlayerName);
            Assert.AreEqual(6, testDice.DiceValue);
            Assert.AreEqual(1, testDice2.DiceValue);
            Assert.ThrowsException<ArgumentNullException>(() => testDice.PlayerName = null);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testDice.PlayerName = "Bo");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testDice.DiceValue = 7);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testDice.DiceValue = 0);
        }

        [TestMethod()]
        public void ToStringTest() {
            DiceResult testDice = new DiceResult("Tobias", 6);
            string str = testDice.ToString();
            Assert.AreEqual("Player name is Tobias Dice Value is: 6", str);
        }
    }
}