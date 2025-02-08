using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Fundamentals.Stack<int?> _stack;

        [SetUp]
        public void SetUp() 
        {
            _stack = new Fundamentals.Stack<int?>();
        }

        [Test]
        public void Push_WhenObjectNull_ThrowsArgumentNullException()
        {
            // Act && Assert
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Count_EmptyStack_ReturnsZero()
        {
            Assert.That(_stack.Count, Is.Zero);
        }

        [Test]
        public void Push_WhenNoNull_ReturnsAddedElements()
        {
            // Act
            _stack.Push(1);

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenNoElements_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCalled_ReturnsDeletedElement()
        {
            _stack.Push(1);
            _stack.Push(2);

            var removedElement = _stack.Pop();
            Assert.That(removedElement, Is.EqualTo(2));
        }

        [Test]
        public void Peek_WhenNoElements_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ReturnTheLastElementWithoutRemovingIt()
        {
            _stack.Push(1);
            _stack.Push(3);

            Assert.That(() => _stack.Peek(), Is.EqualTo(3));
        }

        [TearDown]
        public void TearDown()
        {
            _stack = null!;
        }
    }
}
