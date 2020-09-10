using NUnit.Framework;
using Databas;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            int[] array = new int[16];
            Database database = new Database(array);
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionWhenIsNot16()
        {
            int[] array = new int[18];
            Assert.Throws<InvalidOperationException>(() => new Database(array));
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            Database database = new Database();
            database.Add(1);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddMethodShouldAddOnTheNextEmptyIndex()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database database = new Database(array);
            database.Add(6);
            int expectedResult = 6;
            int actualResult = database.Fetch()[5];
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenAddMoreThan16Elements()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionWhenArrayIsEmpty()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionWhenCountIsZero()
        {
            int[] array = new int[0];
            Database database = new Database(array);
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveCorrectlyLastElement()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);
            database.Remove();
            int[] copyArray = database.Fetch();
            Assert.AreEqual(2, copyArray.Length);
        }

        [Test]
        public void FetchMethodShouldReturnAnArray()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);
            int[] copyArray = database.Fetch();
            int[] expectedArray = { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedArray, copyArray);
        }
    }
}