using Calculator;
using NUnit.Framework;

namespace CalculatorTests
{
    public class ProgramTests
    {
        [Test]
        public void CheckOperation_Space_ReturnsFalse()
        {
            const string operation = " ";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_Nothing_ReturnsFalse()
        {
            const string operation = "";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_3x2_ReturnsFalse()
        {
            const string operation = "3x2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_3plus2_ReturnsFalse()
        {
            const string operation = "3plus2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_3_add_2_x_9_ReturnsFalse()
        {
            const string operation = "3+2x9";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_1_add_x_add_4_ReturnsFalse()
        {
            const string operation = "1+x+4";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_3_BackSlash_2_ReturnsFalse()
        {
            const string operation = "3\\2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_3add2_ReturnsTrue()
        {
            const string operation = "3+2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_3_Divide_2_ReturnsTrue()
        {
            const string operation = "3/2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_3_Minus_2_ReturnsTrue()
        {
            const string operation = "3-2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_3_Multiple_2_ReturnsTrue()
        {
            const string operation = "3*2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_3_Percent_2_ReturnsTrue()
        {
            const string operation = "3%2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_3add2Multiple9_ReturnsTrue()
        {
            const string operation = "3+2*9";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_3add2Multiple9_Divide_3_ReturnsTrue()
        {
            const string operation = "3+2*9/3";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_3add2Multiple9_Divide_3_Minus_1_ReturnsTrue()
        {
            const string operation = "3 + 2*9/3-1";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_CorrectOperation_ReturnsTrue()
        {
            const string operation = "2+15/3+4*2";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_CorrectOperation2_ReturnsTrue()
        {
            const string operation = "1+2*(3+2)";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_FirstElementIsPlus_ReturnsFalse()
        {
            const string operation = "+1+2*(3+2)";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_FirstElementIsMinus_ReturnsTrue()
        {
            const string operation = "-1+2*(3+2)";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.True);
        }

        [Test]
        public void CheckOperation_FirstElementIsMultiple_ReturnsFalse()
        {
            const string operation = "*1+2*(3+2)";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_FirstElementIsDivide_ReturnsFalse()
        {
            const string operation = "/1+2*(3+2)";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_LastElementIsPlus_ReturnsFalse()
        {
            const string operation = "1+2*(3+2)+";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_LastElementIsMinus_ReturnsFalse()
        {
            const string operation = "1+2*(3+2)-";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_LastElementIsMultiple_ReturnsFalse()
        {
            const string operation = "1+2*(3+2)*";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_LastElementIsDivide_ReturnsFalse()
        {
            const string operation = "1+2*(3+2)/";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_LastElementIsDPercent_ReturnsFalse()
        {
            const string operation = "1+2*(3+2)%";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }

        [Test]
        public void CheckOperation_FirstElementIsPlusLastElementIsDPercent_ReturnsFalse()
        {
            const string operation = "+1+2*(3+2)%";
            var currentReturn = Program.CheckOperation(operation);
            Assert.That(currentReturn, Is.False);
        }
    }
}