using LinkedList.Core;

namespace LinkedList.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new SinglyLinkedList<string>();

            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");
            linkedList.AddLast("four");

            INode<string> result = linkedList.Find(null);

        }
    }
}
