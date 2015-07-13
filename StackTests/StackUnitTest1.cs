using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace StackTests
{
    [TestClass]
    public class StackUnitTest1
    {
        [TestMethod]
        public void TestPush()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            int[] expected = { 4, 3, 2, 1 };

            int i = 0;
            foreach (var elem in stack)
            {
                Assert.AreEqual(elem, expected[i++]);
            }
        }

        [TestMethod]
        public void TestPop()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Pop();
            stack.Pop();

            int[] expected = { 2, 1 };

            int i = 0;
            foreach (var elem in stack)
            {
                Assert.AreEqual(elem, expected[i++]);
            }
        }
    }
}
