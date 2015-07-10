using System;
using System.Text;

namespace StackRealization
{
    public class Stack
    {
        private const int DefaultSize = 5;

        private int[] _array;
        private int _top;

        public int Count
        {
            get { return _top + 1; }
        }

        public Stack()
        {
            _top = -1;
            _array = new int[DefaultSize];
        }

        public void Push(int item)
        {
            if (_top == _array.Length + 1)
                Array.Resize(ref _array, _array.Length*2);
            _array[++_top] = item;
        }

        public int Pop()
        {
            if (_top == -1)
                throw new InvalidOperationException();
            return _array[_top--];
        }

        public int Peek()
        {
            if (_top == -1)
                throw new InvalidOperationException();
            return _array[_top];
        }

        public override string ToString()
        {
            StringBuilder stackString = new StringBuilder();
            for (int i = 0; i < _top + 1; i++)
                stackString.Append(_array[i] + " ");
            return stackString.ToString();
        }
    }
}
