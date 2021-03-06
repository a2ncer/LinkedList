﻿using System.Collections.Generic;

namespace LinkedList.Core
{
    /// <summary>
    /// Defines the <see cref="SinglyLinkedList{T}" />.
    /// Implementation of singly linked list.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class SinglyLinkedList<T> : ILinkedList<T>
    {
        private SinglyLinkedListNode<T> _head;
        private SinglyLinkedListNode<T> _tail;
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
            var newitem = new SinglyLinkedListNode<T>
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

                return newitem;
            }

            _tail.Next = newitem;

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
            var (_, target) = FindWithBeforeNode(value);

            return target;
        }

        /// <summary>
        /// The Remove.
        /// </summary>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Remove(T value)
        {
            var (before, target) = FindWithBeforeNode(value);

            if (target == null)
            {
                return false;
            }

            _tail = target.Next == null ? before : _tail;

            if (before == null)
            {
                _head = target.Next;

                return true;
            }

            before.Next = target.Next;

            return true;
        }

        private (SinglyLinkedListNode<T> before, SinglyLinkedListNode<T> target) FindWithBeforeNode(T value)
        {
            if (_head == null || value == null)
            {
                return (null, null);
            }

            var current = _head;
            SinglyLinkedListNode<T> before = null;
            var comparer = EqualityComparer<T>.Default;

            do
            {
                if (comparer.Equals(current.Value, value))
                {
                    return (before, current);
                }

                before = current;
                current = current.Next;

            } while (current != null);

            return (null, null);
        }
    }

    /// <summary>
    /// Defines the <see cref="SinglyLinkedListNode{T}" />.
    /// Internal node for singly linked list.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    internal sealed class SinglyLinkedListNode<T> : INode<T>
    {
        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the next node.
        /// </summary>
        internal SinglyLinkedListNode<T> Next { get; set; }
    }
}
