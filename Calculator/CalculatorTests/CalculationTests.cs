using Calculator;
using NUnit.Framework;

namespace CalculatorTests
{
    public class CalculationTests
    {
        private static Calculation _calculation;
        
        [SetUp]
        public void SetUp()
        {
            _calculation = new Calculation();
        }
        
        [Test]
        public void ShouldReturn_5()
        {
            const string inExpression = "2*2+2/2";
            const string expectedResult = "5";
            var currentResult = _calculation.Result(inExpression);
            Assert.That(currentResult, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void ShouldReturn_11()
        {
            const string inExpression = "1+2*(3+2)";
            const string expectedResult = "11";
            var currentResult = _calculation.Result(inExpression);
            Assert.That(currentResult, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void ShouldReturn_15()
        {
            const string inExpression = "2+15/3+4*2";
            const string expectedResult = "15";
            var currentResult = _calculation.Result(inExpression);
            Assert.That(currentResult, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void ShouldReturn_13()
        {
            const string inExpression = "2+1+(5/2.5)+4*2";
            const string expectedResult = "13";
            var currentResult = _calculation.Result(inExpression);
            Assert.That(currentResult, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void ShouldReturn_ErrorMessage()
        {
            const string inExpression = "2x+1+(5/2.5)+4*2";
            const string expectedResult = "Ошибка в выражении!";
            var currentResult = _calculation.Result(inExpression);
            Assert.That(currentResult, Is.EqualTo(expectedResult));
        }
    }
}