using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace StackTests
{
    [TestClass]
    public abstract class EmptyStack
    {
        protected abstract IStack<int> GetInstance();

        [TestMethod]
        public void Push_EmptyStack()
        {
            var stack = GetInstance();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(stack.Count, 2);

            var i = 2;
            foreach (var e in stack)
                Assert.AreEqual(e, i--);
        }

        [TestMethod]
        public void PushPopPeek_EmptyStack()
        {
            var stack = GetInstance();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Assert.AreEqual(stack.Pop(), 4);
            Assert.AreEqual(stack.Peek(), 3);
            stack.Push(5);
            Assert.AreEqual(stack.Pop(), 5);
            Assert.AreEqual(stack.Pop(), 3);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ThrowException_EmptyStack()
        {
            var stack = GetInstance();

            stack.Pop();
        }
    }

    [TestClass]
    public class EmptyStackTests : EmptyStack
    {
        protected override IStack<int> GetInstance()
        {
            return new Stack<int>();
        }
    }

    [TestClass]
    public class EmptyStackListTests : EmptyStack
    {
        protected override IStack<int> GetInstance()
        {
            return new StackList<int>();
        }
    }
}
