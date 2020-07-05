namespace LinkedList.Core
{
    public interface ILinkedList<T>
    {
        INode<T> AddLast(T value);

        INode<T> Find(T value);

        bool Remove(T value);

        T[] Values { get; }
    }
}
