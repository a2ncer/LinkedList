# LinkedList implementation in C#

![.NET Core](https://github.com/a2ncer/LinkedList/workflows/.NET%20Core/badge.svg?branch=master)

## Requirements

It was required to implement linked list that had the following basic interface and features:
   - The list consists of nodes. Each node has a string value, along with whatever
housekeeping the list itself needs.
   - New nodes are added to the end of the list.
   - You can ask the list if it contains a given string. If it does, it returns the node
containing that string.
   - You can delete a node from the list.
   - You can ask the list to return an array of all its values.

## Solution structure
- LinkedList.Core - implementation of singly and doubly linked lists.
- LinkedList.Sample - simple console application with examples of usage of both types of linked lists.
- LinkedList.Tests - xUnit tests for both implementations.

## LinkedList API
Interfaces:
- ILinkedList<T> - generic interface for linked lists.
- INode<T> - generic interface for node in a linked list.

**ILinkedList<T>** methods:
- INode<T> AddLast(T value) - adds element to the end of the list.
- INode<T> Find(T value) - finds element by value and returns INode<T> or null.
- bool Remove(T value) - removes element from the list by value, if operation is successful - returns true, otherwise - false.

**ILinkedList<T>** properties:
- T[] Values - returns the array of values stored in linked list.

**INode<T>** properties:
- T Value - stores value of type T in a node.

## Sample use cases
```c#
using LinkedList.Core;
using System;
class Program
{
    static void Main(string[] args)
    {
        var linkedList = new DoublyLinkedList<string>(); // or new SinglyLinkedList<string>();
        
        // add some elements to the list
        linkedList.AddLast("one");
        linkedList.AddLast("two");
        linkedList.AddLast("three");
        linkedList.AddLast("four");

        var target = "four";
        // remove target element
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
        // find target element
        var result = linkedList.Find(target);

        if (result != null)
        {
            Console.WriteLine($"Element {target} is found.");
        }
        else
        {
            Console.WriteLine($"Element {target} is not found.");
        }

        // print all elements
        foreach (var elem in linkedList.Values)
        {
            Console.WriteLine(elem);
        }
    }
}
 ```

## License
This project is licensed under the MIT License.
