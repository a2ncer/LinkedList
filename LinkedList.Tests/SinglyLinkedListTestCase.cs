using LinkedList.Core;

namespace LinkedList.Tests
{
    public class SinglyLinkedListTestCase : BaseTestCase
    {
        public override ILinkedList<string> CreateLinkedList()
        {
            return new SinglyLinkedList<string>();
        }
    }
}
