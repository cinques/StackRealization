using System.Collections.Generic;

namespace Stack
{
    public interface IStack<T> : IEnumerable<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        int Count { get; }
    }
}
