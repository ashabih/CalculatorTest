using CalculatorTest.Services.Services;
using CalculatorTest.Services.Services.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalculatorTest.Services.UnitTests.Services
{
    public class SimpleCalculatorTests
    {
        private readonly ISimpleCalculator _simpleCalculator;
        private readonly Mock<IDiagnostics> _mockDiagnostics;

        public SimpleCalculatorTests()
        {
            _mockDiagnostics = new Mock<IDiagnostics>();

            _simpleCalculator = new SimpleCalculator(_mockDiagnostics.Object);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(-5, 10)]
        [InlineData(5, -10)]
        [InlineData(-5, -10)]
        [InlineData(int.MaxValue, -1)]
        [InlineData(int.MinValue, 1)]
        public async Task Add_When_Valid_Numbers_Provided_Then_Returns_The_Sum_Of_Given_NumbersAsync(int start, int amount)
        {
            // Arrange
            var expected = start + amount;

            // Act
            var result = await _simpleCalculator.Add(start, amount);

            // Assert
            result.Should().Be(expected);
            _mockDiagnostics.Verify(x => x.LogMessageAsync($"{nameof(_simpleCalculator.Add)} result: {result}"), Times.Once);
        }

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        [InlineData(int.MaxValue / 2, (int.MaxValue / 2) + 2)]
        [InlineData(int.MinValue / 2, (int.MinValue / 2) - 2)]
        public void Add_When_Numbers_Sum_Outside_Int_Range_Then_Throws_OverflowException(int start, int amount)
        {
            // Arrange
            Func<Task> act = async () => await _simpleCalculator.Add(start, amount);

            // Act/Assert
            act.Should().ThrowAsync<OverflowException>();
            _mockDiagnostics.Verify(x => x.LogMessageAsync(It.IsAny<string>()), Times.Never);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(-5, 10)]
        [InlineData(5, -10)]
        [InlineData(-5, -10)]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        public async Task Subtract_When_Valid_Numbers_Provided_Then_Returns_The_Subtraction_ResultAsync(int start, int amount)
        {
            // Arrange
            var expected = start - amount;

            // Act
            var result = await _simpleCalculator.Subtract(start, amount);

            // Assert
            result.Should().Be(expected);
            _mockDiagnostics.Verify(x => x.LogMessageAsync($"{nameof(_simpleCalculator.Subtract)} result: {result}"), Times.Once);
        }

        [Theory]
        [InlineData(int.MaxValue, -1)]
        [InlineData(int.MinValue, +1)]
        [InlineData(int.MaxValue / 2, ((int.MaxValue / 2) + 2) * -1)]
        [InlineData(int.MinValue / 2, ((int.MinValue / 2) - 2) * -1)]
        public void Subtract_When_Numbers_Subtraction_Results_In_Outside_Int_Range_Then_Throws_OverflowException(int start, int amount)
        {
            // Arrange
            Func<Task> act = async () => await _simpleCalculator.Subtract(start, amount);

            // Act/Assert
            act.Should().ThrowAsync<OverflowException>();
            _mockDiagnostics.Verify(x => x.LogMessageAsync(It.IsAny<string>()), Times.Never);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(-5, 10)]
        [InlineData(5, -10)]
        [InlineData(-5, -10)]
        public async Task Multiply_When_Valid_Numbers_Provided_Then_Returns_The_Multiplication_Of_Given_NumbersAsync(int start, int by)
        {
            // Arrange
            var expected = start * by;

            // Act
            var result = await _simpleCalculator.Multiply(start, by);

            // Assert
            result.Should().Be(expected);
            _mockDiagnostics.Verify(x => x.LogMessageAsync($"{nameof(_simpleCalculator.Multiply)} result: {result}"), Times.Once);
        }

        [Theory]
        [InlineData(int.MaxValue, 2)]
        [InlineData(int.MinValue, 2)]
        [InlineData(int.MaxValue / 2, 3)]
        [InlineData(int.MinValue / 2, 3)]
        public void Multiply_When_Numbers_Multiplication_Outside_Int_Range_Then_Throws_OverflowException(int start, int by)
        {
            // Arrange
            Func<Task> act = async () => await _simpleCalculator.Multiply(start, by);

            // Act/Assert
            act.Should().ThrowAsync<OverflowException>();
            _mockDiagnostics.Verify(x => x.LogMessageAsync(It.IsAny<string>()), Times.Never);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(-5, 10)]
        [InlineData(5, -10)]
        [InlineData(-5, -10)]
        public async Task Divide_When_Valid_Numbers_Provided_Then_Returns_The_Division_Of_Given_NumbersAsync(int start, int by)
        {
            // Arrange
            var expected = start / by;

            // Act
            var result = await _simpleCalculator.Divide(start, by);

            // Assert
            result.Should().Be(expected);
            _mockDiagnostics.Verify(x => x.LogMessageAsync($"{nameof(_simpleCalculator.Divide)} result: {result}"), Times.Once);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 0)]
        [InlineData(int.MaxValue, 0)]
        [InlineData(int.MinValue, 0)]
        public void Divide_When_Divided_By_Zero_Then_Throws_DivideByZeroException(int start, int by)
        {
            // Arrange
            Func<Task> act = async () => await _simpleCalculator.Divide(start, by);

            // Act/Assert
            act.Should().ThrowAsync<DivideByZeroException>();
            _mockDiagnostics.Verify(x => x.LogMessageAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
