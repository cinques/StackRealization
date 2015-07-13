using System;
using Stack;

namespace StackRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            foreach (var e in stack)
            {
                Console.WriteLine(e);
            }

        }
    }
}
