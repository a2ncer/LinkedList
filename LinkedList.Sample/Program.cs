using LinkedList.Core;
using System;

namespace LinkedList.Sample
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            RunSinglyLinkedList();
            RunDoublyLinkedList();

            Console.ReadLine();
        }

        internal static void RunSinglyLinkedList()
        {
            var linkedList = new SinglyLinkedList<string>();

            Console.WriteLine("Running singly linked list...");

            Run(linkedList);
        }

        internal static void RunDoublyLinkedList()
        {
            var linkedList = new DoublyLinkedList<string>();

            Console.WriteLine("Running doubly linked list...");

            Run(linkedList);
        }

        internal static void Run(ILinkedList<string> linkedList)
        {
            if (linkedList == null)
            {
                throw new ArgumentNullException(nameof(linkedList));
            }

            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");
            linkedList.AddLast("four");

            var target = "four";
            var isRemoved = linkedList.Remove(target);

            if (isRemoved)
            {
                Console.WriteLine($"Element {target} is removed.");
            }
            else
            {
                Console.WriteLine($"Element {target} is not removed.");
            }

            target = "two";
            var result = linkedList.Find(target);

            if (result != null)
            {
                Console.WriteLine($"Element {target} is found.");
            }
            else
            {
                Console.WriteLine($"Element {target} is not found.");
            }

            Console.WriteLine("Print elements:");

            foreach (var elem in linkedList.Values)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
