using System.Collections.Generic;
using System.Linq;
using Calculator;
using NUnit.Framework;

namespace CalculatorTests
{
    public class ExpressionsFromFileTests
    {
        private static ExpressionsFromFile _expFromFile;
        private List<string> _expressions;
        
        [SetUp]
        public void SetUp()
        {
            _expFromFile = new ExpressionsFromFile();
            _expressions = _expFromFile.Expressions;
        }
        
        [Test]
        public void ExpressionFromFile_ShouldReturnListWith_5_Elements()
        {
            const int expectedQuantityElementInList = 5;
            var currentQuantityElementInList = _expressions.Count;
            Assert.That(currentQuantityElementInList, Is.EqualTo(expectedQuantityElementInList));
        }

        [Test]
        public void Should_Return_Correct_ExpressionString()
        {
            const string expectedFirstString = "2*2+2/2";
            const string expectedLastString = "2x+1+(5/2.5)+4*2";
            var currentFirstString = _expressions.First();
            var currentLastString = _expressions.Last();
            Assert.That(currentFirstString, Is.EqualTo(expectedFirstString));
            Assert.That(currentLastString, Is.EqualTo(expectedLastString));
        }
    }
}