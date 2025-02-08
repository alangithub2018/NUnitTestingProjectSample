using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
        {
            // Arrange
            var demeritPoints = new DemeritPointsCalculator();

            // Act && Assert
            Assert.That(() => demeritPoints.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(65, 0)]
        [TestCase(70, 1)]
        public void CalculateDemeritPoints_AllowedSpeed_ReturnsDemeritPoints(int speed, int expected)
        {
            // Arrange
            var demeritPoints = new DemeritPointsCalculator();

            // Act
            var result = demeritPoints.CalculateDemeritPoints(65);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
