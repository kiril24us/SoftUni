using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactionsByiD;

        public Chainblock()
        {
            transactionsByiD = new Dictionary<int, ITransaction>();
        }

        public int Count => transactionsByiD.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with {tx.Id} already exists!");
            }

            transactionsByiD.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"Transaction with {id} not exists!");
            }
            transactionsByiD[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx) => this.Contains(tx.Id);

        public bool Contains(int id) => transactionsByiD.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var senders = transactionsByiD.Values
                .Where(x => x.Status == status)
                .OrderBy(x => x.Amount)
                .Select(x => x.From)
                .ToArray();

            if (senders.Length == 0)
            {
                throw new InvalidOperationException("Method should throw InvalidOperationException when there are no such senders");
            }
            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("No such transaction!");
            }

            return transactionsByiD[id];

        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var filtered = transactionsByiD.Values
                                           .Where(x => x.To == receiver
                                           && x.Amount >= lo & x.Amount <= hi)
                                           .OrderByDescending(x => x.Amount)
                                           .ThenBy(x => x.Id).ToArray();
            if (filtered.Length == 0)
            {
                throw new InvalidOperationException("Method should throw InvalidOperationException when there are no such transactions");
            }
            return filtered;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var transactions = transactionsByiD.Values.Where(x => x.Status == status).OrderByDescending(x => x.Amount).ToArray();
            if (transactions.Length == 0)
            {
                throw new InvalidOperationException("Method should throw InvalidOperationException when there are no such transactions");
            }
            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with id - {id} does not exist!");
            }
            transactionsByiD.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
