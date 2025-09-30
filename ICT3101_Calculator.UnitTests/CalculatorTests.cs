using static ICT3101_Calculator.Calculator;

namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToSubtraction()
        {
            // Act
            double result = _calculator.Subtract(30, 20);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void Multiplication_WhenMultiplyingTwoNumbers_ResultEqualToMultiplication()
        {
            // Act
            double result = _calculator.Multiply(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(200));
        }
        [Test]
        public void Division_WhenDividingTwoNumbers_ResultEqualToDivision()
        {
            // Act
            double result = _calculator.Divide(50, 5);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        //[Test]
        //[TestCase(0, 0)]
        //[TestCase(0, 10)]
        //[TestCase(10, 0)]
        //public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
        //{
        //    Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
        //}
        [Test]
        public void Factorial_WhenFactorialaNumber_ResultEqualtoFactorial()
        {
            // Act
            double result = _calculator.Factorial(5);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void Factorial_WithNegativeAsInput_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.Factorial(-5), Throws.ArgumentException);
        }
        [Test]
        public void AreaofTriangle_WhenAreaCalculated_ResultEqualToArea()
        {
            // Act
            double result = _calculator.AreaofTriangle(10, 5);
            // Assert
            Assert.That(result, Is.EqualTo(25));
        }
        [Test]
        [TestCase(-2, 10)]
        [TestCase(10, -2)]
        [TestCase(-4, -2)]
        public void AreaofTriangle_WithNegativeAsInput_ResultThrowArgumentException(double a, double b)
        {
            Assert.That(() => _calculator.AreaofTriangle(a, b), Throws.ArgumentException);
        }
        [Test]
        public void AreaofCircle_WhenAreaCalculated_ResultEqualToArea()
        {
            // Act
            double result = _calculator.AreaofCircle(10);
            // Assert
            Assert.That(result, Is.EqualTo(Math.PI *10*10).Within(0.0001));
        }
        [Test]
        public void AreaofCircle_WithNegativeAsInput_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.AreaofCircle(-2), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionA(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(60));
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest0_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 5);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest1_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest2_Result()
        {
            // Act
            double result = _calculator.UnknownFunctionB(5, 3);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
        }
        [Test]
        public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException()
        {
            // Act
            // Assert
            Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
        }
        public class FakeFileReader : IFileReader
        {
            private readonly string[] _data;

            public FakeFileReader(string[] data)
            {
                _data = data;
            }

            public string[] Read(string path)
            {
                return _data;
            }
        }
        [Test]
        public void GenMagicNum_WhenIndex1Negative_ReturnsPositiveDouble()
        {
            // Arrange
            var fakeReader = new FakeFileReader(new[] { "3.5", "-4.0", "0", "10" });

            // Act
            double result = _calculator.GenMagicNum(1, fakeReader);

            // Assert
            Assert.That(result, Is.EqualTo(8.0)); // -4 * -2
        }

        [Test]
        public void GenMagicNum_WhenIndexOutOfRange_ReturnsZero()
        {
            // Arrange
            var fakeReader = new FakeFileReader(new[] { "3.5", "-4.0" });

            // Act
            double result = _calculator.GenMagicNum(10, fakeReader);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GenMagicNum_WhenFileHasInvalidNumber_ThrowsFormatException()
        {
            // Arrange
            var fakeReader = new FakeFileReader(new[] { "NotANumber" });

            // Act + Assert
            Assert.That(() => _calculator.GenMagicNum(0, fakeReader), Throws.TypeOf<FormatException>());
        }

        [Test]
        public void GenMagicNum_WhenInputIsNegativeIndex_ReturnsZero()
        {
            // Arrange
            var fakeReader = new FakeFileReader(new[] { "3.5", "-4.0" });

            // Act
            double result = _calculator.GenMagicNum(-1, fakeReader);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}