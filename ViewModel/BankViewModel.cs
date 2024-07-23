using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TASK12_2.Model;
using Microsoft.VisualStudio.Services.Account;

namespace TASK12_2.ViewModel
{
    public class BankViewModel /*: BaseViewModel*/
    {
        public ObservableCollection<Client> Clients { get; set; }
        public ICommand AddClientCommand { get; set; }
        public ICommand RemoveAccountCommand { get; set; }
        public ICommand TransferMoneyCommand { get; set; }

        public BankViewModel()
        {
            Clients = new ObservableCollection<Client>();
            AddClientCommand = new RelayCommand(AddClient);
            RemoveAccountCommand = new RelayCommand(RemoveAccount);
            TransferMoneyCommand = new RelayCommand(TransferMoney);
        }

        private void AddClient(object obj)
        {
            // Логика для добавления клиента
            Clients.Add(new Client("New Client", Guid.NewGuid().ToString()));
        }

        private void RemoveAccount(object obj)
        {
            // Логика удаления счета
            if (obj is Account account)
            {
                foreach (var client in Clients)
                {
                    if (client.Accounts.Contains(account))
                    {
                        client.RemoveAccount(account);
                        break;
                    }
                }
            }

        }
        private void TransferMoney(object obj)
        {
            // Логика перевода денег между счетами
        }
    }
}
