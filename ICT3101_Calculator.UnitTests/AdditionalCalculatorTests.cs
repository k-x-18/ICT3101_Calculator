using Moq;
using NUnit.Framework;
using static ICT3101_Calculator.Calculator;

namespace ICT3101_Calculator.UnitTests
{
    [TestFixture]
    public class AdditionalCalculatorTests
    {
        private Calculator _calculator;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockFileReader
                .Setup(fr => fr.Read("MagicNumbers.txt"))
                .Returns(new string[4] { "3.5", "-4.0", "0", "10" });

            _calculator = new Calculator();
        }

        [Test]
        public void GenMagicNum_WhenIndex0Positive_ReturnsDoubleValue()
        {
            // Act
            double result = _calculator.GenMagicNum(0, _mockFileReader.Object);

            // Assert
            Assert.That(result, Is.EqualTo(7.0)); // 3.5 * 2
        }

        [Test]
        public void GenMagicNum_WhenIndex1Negative_ReturnsPositiveDouble()
        {
            // Act
            double result = _calculator.GenMagicNum(1, _mockFileReader.Object);

            // Assert
            Assert.That(result, Is.EqualTo(8.0)); // -4 * -2
        }

        [Test]
        public void GenMagicNum_WhenIndexOutOfRange_ReturnsZero()
        {
            // Act
            double result = _calculator.GenMagicNum(10, _mockFileReader.Object);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GenMagicNum_WhenFileHasInvalidNumber_ThrowsFormatException()
        {
            // Arrange – change mock return value for this test
            _mockFileReader
                .Setup(fr => fr.Read("MagicNumbers.txt"))
                .Returns(new[] { "NotANumber" });

            // Act + Assert
            Assert.That(() => _calculator.GenMagicNum(0, _mockFileReader.Object),
                        Throws.TypeOf<FormatException>());
        }

        [Test]
        public void GenMagicNum_WhenInputIsNegativeIndex_ReturnsZero()
        {
            // Act
            double result = _calculator.GenMagicNum(-1, _mockFileReader.Object);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
