using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>, IEnumerable, ICollection
    {
        private const int DefaultSize = 50;

        private T[] _array;
        private int _top;

        public int Count
        {
            get { return _top + 1; }
        }

        public Stack()
        {
            _top = -1;
            _array = new T[0];
        }

        public void Push(T item)
        {
            if (_top + 1 == _array.Length)
                Array.Resize(ref _array, _array.Length == 0 ? DefaultSize : _array.Length * 2);
            _array[++_top] = item;
        }

        public T Pop()
        {
            if (_top == -1)
                throw new InvalidOperationException();
            return _array[_top--];
        }

        public T Peek()
        {
            if (_top == -1)
                throw new InvalidOperationException();
            return _array[_top];
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        #region ICollection

        public object SyncRoot { get { return this; } }

        public bool IsSynchronized { get { return false; } }

        public void CopyTo(Array array, int index)
        {
            try
            {
                _array.CopyTo(array, index);
                Array.Reverse(array, index, _top);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException();
            }
        }

        #endregion

        #region IEnumerable

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Enumerator : IEnumerator<T>, IEnumerator
        {
            private Stack<T> _stack;
            private int _index;

            public Enumerator(Stack<T> stack)
            {
                _stack = stack;
                _index = -2;
            }

            public bool MoveNext()
            {
                if (_index == -2)
                    _index = _stack._top + 1;

                return --_index != -1;
            }

            public T Current
            {
                get
                {
                    if (_index < 0)
                        throw new InvalidOperationException();
                    return _stack._array[_index];
                }
            }

            void IEnumerator.Reset()
            {
                _index = -2;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                _index = -1;
            }
        }

        #endregion
    }

}