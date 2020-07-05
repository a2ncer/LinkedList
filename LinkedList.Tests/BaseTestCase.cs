using LinkedList.Core;
using System.Collections.Generic;
using Xunit;

namespace LinkedList.Tests
{
    public abstract class BaseTestCase
    {
        [Fact]
        public void AddLastDoAddingElemntToTheEndWhenCallingMethodTest()
        {
            var linkedList = CreateLinkedList();

            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");

            var expected = new List<string>() { "one", "two", "three" };

            var actual = linkedList.Values;

            Assert.Equal(expected.ToArray(), actual);

            linkedList.AddLast("four");

            actual = linkedList.Values;

            expected.Add("four");

            Assert.Equal(expected.ToArray(), actual);
        }

        public abstract ILinkedList<string> CreateLinkedList();

        [Fact]
        public void FindDoFindElementWhenExistsTest()
        {
            var linkedList = CreateLinkedList();

            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");

            var actual = linkedList.Find("two");

            Assert.Equal("two", actual.Value);

            actual = linkedList.Find("one");

            Assert.Equal("one", actual.Value);

            actual = linkedList.Find("three");

            Assert.Equal("three", actual.Value);
        }

        [Fact]
        public void FindDoGetNullWhenElementDoesNotExistOrNullTest()
        {
            var linkedList = CreateLinkedList();

            Assert.Empty(linkedList.Values);

            var actual = linkedList.Find("someValue");

            Assert.Null(actual);

            actual = linkedList.Find("someValue");

            Assert.Null(actual);

            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");

            actual = linkedList.Find("five");

            Assert.Null(actual);

            actual = linkedList.Find("");

            Assert.Null(actual);

            actual = linkedList.Find(null);

            Assert.Null(actual);
        }

        [Fact]
        public void RemoveReturnsFalseWhenElementDoesNotExistTest()
        {
            var linkedList = CreateLinkedList();

            var actual = linkedList.Remove("someValue");

            Assert.False(actual);
            Assert.Equal(new string[] { }, linkedList.Values);

            actual = linkedList.Remove(null);

            Assert.False(actual);
            Assert.Equal(new string[] { }, linkedList.Values);

            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");

            actual = linkedList.Remove("someValue");

            Assert.False(actual);
            Assert.Equal(new string[] { "one", "two", "three" }, linkedList.Values);
        }

        [Fact]
        public void RemoveReturnsTrueWhenElementExistsTest()
        {
            var linkedList = CreateLinkedList();
            linkedList.AddLast("zero");
            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");
            linkedList.AddLast("four");

            Assert.Equal(new string[] { "zero", "one", "two", "three", "four" }, linkedList.Values);

            var actual = linkedList.Remove("zero");

            Assert.True(actual);
            Assert.Equal(new string[] { "one", "two", "three", "four" }, linkedList.Values);

            actual = linkedList.Remove("four");

            Assert.True(actual);
            Assert.Equal(new string[] { "one", "two", "three" }, linkedList.Values);

            actual = linkedList.Remove("two");

            Assert.True(actual);
            Assert.Equal(new string[] { "one", "three" }, linkedList.Values);

            actual = linkedList.Remove("three");

            Assert.True(actual);
            Assert.Equal(new string[] { "one" }, linkedList.Values);

            actual = linkedList.Remove("one");

            Assert.True(actual);
            Assert.Equal(new string[] { }, linkedList.Values);

            linkedList.AddLast("one");
            linkedList.AddLast("two");
            linkedList.AddLast("three");

            actual = linkedList.Remove("three");

            Assert.True(actual);
            Assert.Equal(new string[] { "one", "two" }, linkedList.Values);

            linkedList.AddLast("three");

            Assert.True(actual);
            Assert.Equal(new string[] { "one", "two", "three" }, linkedList.Values);
        }
    }
}
