using Calculator;
using NUnit.Framework;

namespace CalculatorTests
{
    public class MathematicalOperationsTest
    {
        [Test]
        public void Add_34_21_ShouldReturn_55()
        {
            const string expression = "34+21";
            const string expectedResult = "55";
            var calc = new PlusMinusCalculate(expression);
            var currentCalc = calc.ToString();
            Assert.That(currentCalc, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Subtract_34point5_21_ShouldReturn_13_point_5()
        {
            const string expression = "34.5-21";
            const string expectedResult = "13.5";
            var calc = new PlusMinusCalculate(expression);
            var currentCalc = calc.ToString();
            Assert.That(currentCalc, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Subtract_Negative_3_2_ShouldReturn_Negative_5()
        {
            const string expression = "-3-2";
            const string expectedResult = "-5";
            var calc = new PlusMinusCalculate(expression);
            var currentCalc = calc.ToString();
            Assert.That(currentCalc, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Subtract_Negative_6_point_5_and_2_ShouldReturn_Negative_4_point_5()
        {
            const string expression = "6.5-2";
            const string expectedResult = "4.5";
            var calc = new PlusMinusCalculate(expression);
            var currentCalc = calc.ToString();
            Assert.That(currentCalc, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Multiple_3_2_ShouldReturn_Negative_6()
        {
            const string expression = "3*2";
            const string expectedResult = "6";
            var calc = new MultDivCalculate(expression);
            var currentCalc = calc.ToString();
            Assert.That(currentCalc, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Multiple_Negative_2_point_5_And_3_ShouldReturn_Negative_Negative_7_point_5()
        {
            const string expression = "-2.5*3";
            const string expectedResult = "-7.5";
            var calc = new MultDivCalculate(expression);
            var currentCalc = calc.ToString();
            Assert.That(currentCalc, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Divide_Negative_7_point_5_And_3_ShouldReturn_Negative_Negative_2_point_5()
        {
            const string expression = "-7.5/3";
            const string expectedResult = "-2.5";
            var calc = new MultDivCalculate(expression);
            var currentCalc = calc.ToString();
            Assert.That(currentCalc, Is.EqualTo(expectedResult));
        }
    }
}