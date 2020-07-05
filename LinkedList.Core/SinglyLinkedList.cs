using System.Collections.Generic;

namespace LinkedList.Core
{
    public class SinglyLinkedList<T> : ILinkedList<T>
    {
        private SinglyLinkedListNode<T> _head;
        private SinglyLinkedListNode<T> _tail;
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

        public INode<T> Find(T value)
        {
            var (_, target) = FindWithBeforeNode(value);

            return target;
        }

        public bool Remove(T value)
        {
            var (before, target) = FindWithBeforeNode(value);

            if (target == null)
            {
                return false;
            }

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

    internal sealed class SinglyLinkedListNode<T> : INode<T>
    {
        public T Value { get; set; }

        internal SinglyLinkedListNode<T> Next { get; set; }
    }
}
