using System;

namespace StackRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(2);
            stack.Push(44);
            stack.Push(3);
            stack.Push(12);
            Console.WriteLine(stack);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);
        }
    }
}
