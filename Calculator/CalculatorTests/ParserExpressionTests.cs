using NUnit.Framework;
using Calculator;

namespace CalculatorTests
{
    public class ParserExpressionTests
    {
        [Test]
        public void ShouldReturn_11()
        {
            const string inExpression = "1+2*(3+2)";
            const string expectedOut = "11";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }

        [Test]
        public void ShouldReturn_negative_3()
        {
            const string inExpression = "-12.5+(2+2)+3.5+2";
            const string expectedOut = "-3";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }

        [Test]
        public void ShouldReturn_negative_6()
        {
            const string inExpression = "2.5+(2+2)+(3.5+2)";
            const string expectedOut = "12";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }

        [Test]
        public void ShouldReturn_1()
        {
            const string inExpression = "2+((2*2)-5)";
            const string expectedOut = "1";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }

        [Test]
        public void ShouldReturn_negative_5()
        {
            const string inExpression = "-3-2";
            const string expectedOut = "-5";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedOut));
        }

        [Test]
        public void ShouldReturn_5()
        {
            const string inExpression = "2*2+2/2";
            const string expectedResult = "5";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturn_21()
        {
            const string inExpression = "10+2*(3+2)";
            const string expectedResult = "20";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturn_15()
        {
            const string inExpression = "2+15/3+4*2";
            const string expectedResult = "15";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturn_13()
        {
            const string inExpression = "2+1+(5/2.5)+4*2";
            const string expectedResult = "13";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturn_ErrorMessage()
        {
            const string inExpression = "2x+1+(5/2.5)+4*2";
            const string expectedResult = "Ошибка в выражении!";
            var parse = new ParseExpression(inExpression);
            parse.Result();
            var currentOut = parse.Result();
            Assert.That(currentOut, Is.EqualTo(expectedResult));
        }
    }
}