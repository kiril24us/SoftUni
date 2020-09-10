using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private IChainblock chainblock;
        [SetUp]
        public void Initialize()
        {
            chainblock = new Chainblock();
        }

        [Test]
        public void AddMethodShouldAddSuccessfullyAndIncreaseTheCount()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100); ;
            chainblock.Add(transaction);
            Assert.That(chainblock.Count, Is.EqualTo(1), "Count should be equal to 1");
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationWhenIdAlreadyExists()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100); ;
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(
                () => chainblock.Add(transaction), $"transaction already exist!");
            Assert.That(chainblock.Count, Is.EqualTo(1), "The Count shouldn't increase");
        }

        [Test]
        public void ContainsShouldReturnTrueWithExistingTransaction()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100); ;
            chainblock.Add(transaction);
            var isExisting = chainblock.Contains(transaction);
            Assert.That(isExisting, Is.EqualTo(true), "Contains should return true with existing transaction");
        }

        [Test]
        public void ContainsShouldReturnFalseWithNonExistingTransaction()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Aborted, "da", "friend", 100);
            chainblock.Add(transaction);
            var isExisting = chainblock.Contains(transaction2);
            Assert.That(isExisting, Is.EqualTo(false), "Contains should return false with not existing transaction");
        }

        [Test]
        public void ContainsShouldReturnTrueWithExistingTransactionId()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100); ;
            chainblock.Add(transaction);
            var isExisting = chainblock.Contains(1);
            Assert.That(isExisting, Is.EqualTo(true), "Contains should return true with existing transaction Id");
        }

        [Test]
        public void ContainsShouldReturnFalseWithNonExistingTransactionId()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100);
            chainblock.Add(transaction);
            var isExisting = chainblock.Contains(2);
            Assert.That(isExisting, Is.EqualTo(false), "Contains should return false with not existing transaction Id");
        }

        [Test]
        public void ChangeTransactionStatusSuccessfullyWithGivenId()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100);
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Successfull);
            var actualTransaction = chainblock.GetById(transaction.Id);
            Assert.That(actualTransaction.Status, Is.EqualTo(TransactionStatus.Successfull), "Transaction status is not changed");
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowArgumentExceptionIfNoSuchTransactionExist()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(1, TransactionStatus.Successfull),
                "Change Status with no existing Id should throw ArgumentException");
        }

        [Test]
        public void GetByIdReturnSuccessfullyTransactionById()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100);
            chainblock.Add(transaction);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Aborted, "me", "friend", 100);
            chainblock.Add(transaction2);
            var actualTransaction = chainblock.GetById(1);
            Assert.That(actualTransaction, Is.EqualTo(transaction), "Transactions are unique");
        }

        [Test]
        public void GetByIdShouldReturnInvalidOperationExceptionIfSuchTransactionDoesntExist()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100);
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(2), "Get by id with non existing transaction should throw an exception");
        }

        [Test]
        public void RemoveMethodShouldRemoveTransactionIfIdExist()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Aborted, "me", "friend", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            chainblock.RemoveTransactionById(1);
            Assert.That(chainblock.Count, Is.EqualTo(1), "Count is not decrease");
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionIfIdNotExist()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "me", "friend", 100);
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(2), $"Transaction with Id 2 does not exist!");
        }

        [Test]
        public void GetByTransactionStatusShouldThrowInvalidOperationExceptionWhenThereAreNoSuchTransactions()
        {
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 3);
                ITransaction transaction = new Transaction(i, status, "me", "friend", i);
                chainblock.Add(transaction);
            }
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized), $"Method should throw InvalidOperationException when there are no such transactions!");
        }

        [Test]
        public void GetByTransactionStatusShouldReturnSuccessfullyTransactionsWithGivenStatusOrderedByAmountDescending()
        {
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 4);
                ITransaction transaction = new Transaction(i, status, "me", "friend", i);
                chainblock.Add(transaction);
            }

            var actualTransactions = chainblock.GetByTransactionStatus(TransactionStatus.Aborted).ToArray();
            double amount = actualTransactions[0].Amount;
            for (int i = 1; i < actualTransactions.Length; i++)
            {
                var currentTransaction = actualTransactions[i];
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(amount));

                amount = currentTransaction.Amount;

                Assert.That(actualTransactions[i - 1].Status, Is.EqualTo(TransactionStatus.Aborted));
            }
        }
        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenThereAreNoSuchTransactions()
        {
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 3);
                ITransaction transaction = new Transaction(i, status, "me", "friend", i);
                chainblock.Add(transaction);
            }
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized), $"Method should throw InvalidOperationException when there are no such transactions!");
        }

        [Test]
        public void GetAllSendersWithTransactionStatusReturnSendersSuccessfullyorderByTransactionAmount()
        {
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 3);
                ITransaction transaction = new Transaction(i, status, "me", "friend", i);
                chainblock.Add(transaction);
            }
            ITransaction transaction2 = new Transaction(10, TransactionStatus.Successfull, "az", "toi", 100);
            chainblock.Add(transaction2);
            var filteredTransactions = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToArray();
            for (int i = 0; i < filteredTransactions.Length - 1; i++)
            {
                var sender = filteredTransactions[i];

                Assert.That(sender, Is.EqualTo("me"));
            }
            var expectedLastSender = transaction2.From;
            var actualSender = filteredTransactions[filteredTransactions.Length - 1];
            Assert.That(actualSender, Is.EqualTo(expectedLastSender));
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionWhenThereAreNoSuchTransactions()
        {
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 3);
                ITransaction transaction = new Transaction(i, status, "me", "friend", i);
                chainblock.Add(transaction);
            }
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("az", 2, 3), $"Method should throw InvalidOperationException when there are no such transactions!");
        }

        [Test]
        public void GetByReceiverAndAmountRangeReturnTransactionsSuccessfullyOrderByTransactionAmountDescending()
        {
            var receiver = "Peter";
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 4);
                receiver = i % 2 == 0 ? receiver : "George";
                ITransaction transaction = new Transaction(i, status, "me", receiver, i + 50);
                chainblock.Add(transaction);
            }

            double amount = double.MaxValue;
            var filteredTransactions = chainblock.GetByReceiverAndAmountRange(receiver, 50, 55).ToArray();
            foreach (ITransaction tx in filteredTransactions)
            {
                var sender = tx.To;

                Assert.That(sender, Is.EqualTo(receiver));
                Assert.That(tx.Amount, Is.LessThanOrEqualTo(55).And.GreaterThanOrEqualTo(50), "Transactions should be in the given range");
                Assert.That(tx.Amount, Is.LessThan(amount), "Filtered transactions must be ordered by Amount");
                amount = tx.Amount;
            }
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionWhenRangeIsInvalid()
        {
            var receiver = "Peter";
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 4);
                ITransaction transaction = new Transaction(i, status, "me", receiver, i + 50);
                chainblock.Add(transaction);
            }

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange(receiver, int.MinValue, 49));
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange(receiver, 60, int.MaxValue));
        }

        [Test]
        public void GetByReceiverAndAmountRangeWithEqualsAmountsShouldOrderThenById()
        {
            var receiver = "Peter";
            for (int i = 0; i < 10; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 4);
                receiver = i % 2 == 0 ? receiver : "George";
                ITransaction transaction = new Transaction(i, status, "me", receiver, 100);
                chainblock.Add(transaction);
            }

            double id = double.MinValue;
            var filteredTransactions = chainblock.GetByReceiverAndAmountRange(receiver, 50, 102)
                                                 .Where(x => x.Amount == 100).ToArray();
            foreach (ITransaction tx in filteredTransactions)
            {
                Assert.That(tx.Id, Is.GreaterThan(id));
                Assert.That(tx.To, Is.EqualTo(receiver));
                id = tx.Id;
            }
        }
    }
}
