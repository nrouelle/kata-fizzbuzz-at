using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Dojo
{
    [TestFixture]
    public class GameShould
    {
        [Test]
        public void Return100LinesWhenRun()
        {
            Assert.That(Game.Run().Count == 100);
        }
        

        [Test]
        [TestCase(0, "1")]
        [TestCase(1, "2")]
        [TestCase(2, Game.Fizz)]
        [TestCase(3, "4")]
        [TestCase(4, Game.Buzz)]
        [TestCase(5, Game.Fizz)]
        [TestCase(9, Game.Buzz)]
        [TestCase(12, Game.Fizz)]
        [TestCase(14, "FizzBuzz")]
        [TestCase(29, "FizzBuzz")]
        [TestCase(34, "FizzBuzz")]
        [TestCase(51, Game.Buzz)]
        [TestCase(52, "FizzBuzz")]
        [TestCase(99, Game.Buzz)]
        public void ReturnValeurWhenIndex(int index, string valeur)
        {
            Assert.AreEqual(valeur, Game.Run()[index]);
        }
    }

    public class Game
    {
        public const string Fizz = "Fizz";
        public const string Buzz = "Buzz";

        public static List<string> Run()
        {
            var result = new List<string>();

            for (int i = 1; i < 101; i++)
            {
                result.Add(ConvertIndexToValue(i));
            }

            return result;
        }

        private static string ConvertIndexToValue(int index)
        {
            var fizzBuzz = string.Concat(GetFizz(index), GetBuzz(index));

            if (!string.IsNullOrEmpty(fizzBuzz))
                return fizzBuzz;
            return index.ToString();

        }

        private static string GetFizz(int index)
        {
            var isMultipleOf3 = index % 3 == 0;
            return isMultipleOf3 || index.ToString().Contains("3") ? Fizz : String.Empty;
        }

        private static string GetBuzz(int index)
        {
            var isMultipleOf5 = index % 5 == 0;
            return isMultipleOf5 || index.ToString().Contains("5") ? Buzz : String.Empty;
        }
    }
}
