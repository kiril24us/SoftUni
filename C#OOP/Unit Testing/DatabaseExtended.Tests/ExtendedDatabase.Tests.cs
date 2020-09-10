using NUnit.Framework;
using ExtendedDatabas;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MethodAddShouldThrowAnInvalidOperationExceptionIfThereIsAlreadyThatUsername()
        {
            Person person = new Person( 7, "Andrei" );
            Person[] people = new[]
            {
                new Person(1, "Andrei"),
            };
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(person));
        }

        [Test]
        public void MethodAddShouldThrowAnInvalidOperationExceptionIfThereIsAlreadyThatUserId()
        {
            Person person = new Person(7, "Gosho");
            Person[] people = new[]
            {
                new Person(7, "Andrei"),
            };
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(person));
        }

        [Test]
        public void RemoveMethodShouldThrownInvalidOperationExceptionWhenCountIsZero()
        {           
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemovePersonAndDecreaseCount()
        {
            Person[] people = new[]
           {
                new Person(7, "Andrei"),
                new Person(1, "Ivan")
            };
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(people);
            extendedDatabase.Remove();
            Assert.AreEqual(1, extendedDatabase.Count);
        }

        [TestCase("")]
        [TestCase(null)]
        public void MethodFindByUsernameShouldThrowInvalidOperationExceptionWhenNameIsZeroOrEmpty(string name)
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(name));
        }

        [Test]
        public void MethodFindByUsernameShouldThrowInvalidOperationExceptionWhenThereIsNoSuchUser()
        {
            string name = "Ivan";
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername(name));
        }

        [Test]
        public void MethodFindByUsernameShouldReturnPersonWhenThereIsAlreadySuchUser()
        {
            var person = new Person(1, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);
            var expectedPerson = extendedDatabase.FindByUsername("Ivan");
            Assert.AreEqual(expectedPerson, person);
        }

        [Test]
        public void MethodFindByIdShouldThrowArgumentOutOfRangeExceptionWhenIdIsNegativeNumber()
        {
            int id = -2;
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(id));
        }

        [Test]
        public void MethodFindByIdShouldThrowInvalidOperationExceptionWhenThereIsNoSuchId()
        {
            int id = 1;
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(id));
        }

        [Test]
        public void MethodFindByIdShouldReturnPersonWhenThereIsAlreadySuchUser()
        {
            var person = new Person(1, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);
            var expectedPerson = extendedDatabase.FindById(1);
            Assert.AreEqual(expectedPerson, person);
        }
    }
}