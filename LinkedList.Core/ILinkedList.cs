namespace LinkedList.Core
{
    /// <summary>
    /// Defines the <see cref="ILinkedList{T}" />.
    /// Common interface for LinkedList.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface ILinkedList<T>
    {
        /// <summary>
        /// Adds element to the end of the list.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <returns>The <see cref="INode{T}"/>.</returns>
        INode<T> AddLast(T value);

        /// <summary>
        /// Finds element by value and returns INode<T> or null.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <returns>The <see cref="INode{T}"/>.</returns>
        INode<T> Find(T value);

        /// <summary>
        /// Removes element from the list by value. 
        /// If operation is successful - returns true, otherwise - false.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool Remove(T value);

        /// <summary>
        /// Returns the array of values.
        /// </summary>
        T[] Values { get; }
    }
}
