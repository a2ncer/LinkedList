using System.Collections.Generic;

namespace LinkedList.Core
{
    /// <summary>
    /// Defines the <see cref="DoublyLinkedList{T}" />.
    /// Implementation of doubly linked list.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class DoublyLinkedList<T> : ILinkedList<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;
        /// <summary>
        /// Returns the array of values.
        /// </summary>
        public T[] Values
        {
            get
            {
                var values = new List<T>();

                if (_head == null)
                {
                    return values.ToArray();
                }

                var current = _head;
                do
                {
                    values.Add(current.Value);
                    current = current.Next;
                }
                while (current != null);

                return values.ToArray();
            }
        }

        /// <summary>
        /// Adds element to the end of the list.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <returns>The <see cref="INode{T}"/>.</returns>
        public INode<T> AddLast(T value)
        {
            var newitem = new DoublyLinkedListNode<T>
            {
                Value = value
            };

            if (_head == null)
            {
                _head = newitem;

                return newitem;
            }

            if (_tail == null)
            {
                _tail = newitem;
                _head.Next = _tail;
                _tail.Prev = _head;

                return newitem;
            }

            _tail.Next = newitem;
            newitem.Prev = _tail;
            _tail = newitem;

            return newitem;
        }

        /// <summary>
        /// The Find.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <returns>The <see cref="INode{T}"/>.</returns>
        public INode<T> Find(T value)
        {
            return InternalFind(value);
        }

        /// <summary>
        /// The Remove.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Remove(T value)
        {
            var current = InternalFind(value);

            if (current == null)
            {
                return false;
            }

            var prev = current.Prev;
            var next = current.Next;

            if (prev != null)
            {
                prev.Next = next;
            }
            else
            {
                _head = next;
            }

            if (next != null)
            {
                next.Prev = prev;
            }
            else
            {
                _tail = prev;
            }

            return true;
        }

        private DoublyLinkedListNode<T> InternalFind(T value)
        {
            if (_head == null)
            {
                return null;
            }

            var current = _head;
            var comparer = EqualityComparer<T>.Default;
            do
            {
                if (comparer.Equals(current.Value, value))
                {
                    return current;
                }
                current = current.Next;
            }
            while (current != null);

            return null;
        }
    }

    /// <summary>
    /// Defines the <see cref="DoublyLinkedListNode{T}" />.
    /// Internal node for doubly linked list.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    internal sealed class DoublyLinkedListNode<T> : INode<T>
    {
        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the next node.
        /// </summary>
        internal DoublyLinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Gets or sets the previous node.
        /// </summary>
        internal DoublyLinkedListNode<T> Prev { get; set; }
    }
}
