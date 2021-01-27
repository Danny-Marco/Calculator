using NUnit.Framework;
using Calculator;

namespace CalculatorTests
{
    public class ParserExpressionTests
    {
        [Test]
        public void ShouldReturn_11()
        {
            const string userInput = "1+2*(3+2)";
            const string expectedOut = "11";
            var parse = new ParseExpression(userInput);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }
        
        [Test]
        public void ShouldReturn_negative_3()
        {
            const string userInput = "-12.5+(2+2)+3.5+2";
            const string expectedOut = "-3";
            var parse = new ParseExpression(userInput);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }
        
        [Test]
        public void ShouldReturn_negative_6()
        {
            const string userInput = "2.5+(2+2)+(3.5+2)";
            const string expectedOut = "12";
            var parse = new ParseExpression(userInput);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }
        
        [Test]
        public void ShouldReturn_1()
        {
            const string userInput = "2+((2*2)-5)";
            const string expectedOut = "1";
            var parse = new ParseExpression(userInput);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }
        
        [Test]
        public void ShouldReturn_negative_5()
        {
            const string userInput = "-3-2";
            const string expectedOut = "-5";
            var parse = new ParseExpression(userInput);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }
    }
}