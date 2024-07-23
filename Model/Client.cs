using Microsoft.VisualStudio.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TASK12_2.Model
{
    public class Client
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<Account> Accounts { get; set; } 

        public Client(string name, string id)
        {
            Name = name;
            Id = id;
            Accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void RemoveAccount(Account account)
        {
            Accounts.Remove(account);
        }
    }
    // Обобщённый класс счета
    public class Account<T> where T : struct, IConvertible
    {
        public string AccountId { get; private set; }
        public T Balance { get; private set; }

        public Account(string accountId, T initialBalance)
        {
            AccountId = accountId;
            Balance = initialBalance;
        }

        public void Deposit(T amount)
        {
            Balance = (dynamic)Balance + (dynamic)amount;
        }

        public bool Withdraw(T amount)
        {
            if (Convert.ToDouble(Balance) >= Convert.ToDouble(amount))
            {
                Balance = (dynamic)Balance - (dynamic)amount;
                return true;
            }
            return false;
        }

        public bool Transfer(Account<T> targetAccount, T amount)
        {
            if (Withdraw(amount))
            {
                targetAccount.Deposit(amount);
                return true;
            }
            return false;
        }
    }
}
