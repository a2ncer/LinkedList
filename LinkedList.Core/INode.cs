namespace LinkedList.Core
{
    /// <summary>
    /// Defines the <see cref="INode{T}" />.
    /// Common interface for Node that is used in LinkedList.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface INode<T>
    {
        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        T Value { get; set; }
    }
}
