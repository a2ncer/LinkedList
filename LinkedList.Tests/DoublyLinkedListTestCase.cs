using LinkedList.Core;

namespace LinkedList.Tests
{
    public class DoublyLinkedListTestCase : BaseTestCase
    {
        public override ILinkedList<string> CreateLinkedList()
        {
            return new DoublyLinkedList<string>();
        }
    }
}
