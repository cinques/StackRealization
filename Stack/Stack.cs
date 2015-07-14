using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    /// <summary>
    /// Realization of the stack.
    /// </summary>
    public class Stack<T> : IEnumerable<T>, ICollection
    {
        /// <summary>
        /// Initial capacity of the stack.
        /// </summary>
        private const int InitialCapacity = 4;
        /// <summary>
        /// Storage for stack elements.
        /// </summary>
        private T[] _array;
        /// <summary>
        /// Top of the stack.
        /// </summary>
        private int _top;

        /// <summary>
        /// Number of elements in the stack.
        /// </summary>
        public int Count
        {
            get { return _top + 1; }
        }

        /// <summary>
        /// Create an empty stack.
        /// </summary>
        public Stack()
        {
            _array = new T[0];
            _top = -1;
        }

        /// <summary>
        /// Create a stack with your own specific capacity.
        /// </summary>
        /// <param name="capacity">Specific capacity</param>
        public Stack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _array = new T[capacity];
            _top = -1;
        }

        /// <summary>
        /// Create a stack copied from another collection.
        /// </summary>
        /// <param name="collection">Another collection to copy.</param>
        public Stack(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            ICollection<T> c = collection as ICollection<T>;

            if (c == null)
            {
                _array = new T[InitialCapacity];
                _top = -1;

                foreach (var e in collection)
                    Push(e);
            }
            else
            {
                _array = new T[c.Count];
                _top = c.Count - 1;
                c.CopyTo(_array, 0);
            }
        }

        /// <summary>
        /// Pushes an item to the top of the stack.
        /// </summary>
        /// <param name="item">Item to push.</param>
        public void Push(T item)
        {
            if (_top + 1 == _array.Length)
                Array.Resize(ref _array, _array.Length == 0 ? InitialCapacity : _array.Length * 2);
            _array[++_top] = item;
        }

        /// <summary>
        /// Pops an item from the top of the stack.
        /// </summary>
        /// <returns>Popped item.</returns>
        public T Pop()
        {
            if (_top == -1)
                throw new InvalidOperationException();
            T popped = _array[_top];
            _array[_top--] = default(T);
            return popped;
        }

        /// <summary>
        /// Sees item on the top of the stack without removing it.
        /// </summary>
        /// <returns>Item on the top.</returns>
        public T Peek()
        {
            if (_top == -1)
                throw new InvalidOperationException();
            return _array[_top];
        }

        /// <summary>
        /// Romoves all items of the stack.
        /// </summary>
        public void Clear()
        {
            Array.Clear(_array, 0, _top + 1);
            _top = -1;
        }

        /// <summary>
        /// Checks that the stack contains specified item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return _array.Contains(item);
        }

        /// <summary>
        /// Compress the size of the stack.
        /// </summary>
        public void TrimeExcess()
        {
            int newSize = (int)(_array.Length*0.9);
            if (_top + 1 < newSize)
                Array.Resize(ref _array, newSize);
        }


        #region ICollection

        public object SyncRoot { get { return this; } }

        public bool IsSynchronized { get { return false; } }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (index < 0)
                throw new ArgumentOutOfRangeException();
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
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Enumerator : IEnumerator<T>
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