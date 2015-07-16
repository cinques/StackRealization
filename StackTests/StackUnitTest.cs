using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace StackTests
{
    [TestClass]
    public class StackUnitTest
    {
        [TestMethod]
        public void TestConstructors()
        {
            Stack<int> stack1 = new Stack<int>();
            Assert.AreEqual(stack1.Count, 0);

            Stack<int> stack2 = new Stack<int>(5);
            int[] expected = { 0, 0, 0, 0, 0 };
            int i = 0;
            foreach (var e in stack2)
                Assert.AreEqual(e, expected[i++]);

            Stack<int> stack3 = new Stack<int>(new[] { 1, 2, 3, 4 });
            expected = new[] { 4, 3, 2, 1 };
            i = 0;
            foreach (var e in stack3)
                Assert.AreEqual(e, expected[i++]);
        }

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
            foreach (var e in stack)
                Assert.AreEqual(e, expected[i++]);
        }

        [TestMethod]
        public void TestPop()
        {
            Stack<int> stack = new Stack<int>(new[] {1, 2, 3, 4});
            stack.Pop();
            stack.Pop();

            int[] expected = { 2, 1 };
            int i = 0;
            foreach (var e in stack)
                Assert.AreEqual(e, expected[i++]);
        }

        [TestMethod]
        public void TestPeek()
        {
            Stack<int> stack = new Stack<int>(new[] { 1, 2, 3, 4 });
            Assert.AreEqual(stack.Peek(), 4);
        }

        [TestMethod]
        public void TestClear()
        {
            Stack<int> stack = new Stack<int>(new[] { 1, 2, 3, 4 });
            stack.Clear();
            Assert.AreEqual(stack.Count, 0);
        }

        [TestMethod]
        public void TestContains()
        {
            Stack<int> stack = new Stack<int>(new[] { 1, 2, 3, 4 });
            Assert.AreEqual(stack.Contains(2), true);
            Assert.AreEqual(stack.Contains(5), false);
        }
    }
}
