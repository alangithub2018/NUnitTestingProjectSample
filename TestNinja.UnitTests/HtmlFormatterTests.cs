using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            // Arrange
            var htmlFormatter = new HtmlFormatter();

            // Act
            var result = htmlFormatter.FormatAsBold("abc");

            // Assert
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase); // Specific

            Assert.That(result, Does.StartWith("<strong>").IgnoreCase); // General
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));

        }
    }
}
