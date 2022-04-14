using AdvanceNavigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceNavigation.Stores
{
    public class AccountStore
    {
        public Account _currentAccount;

        public Account  CurrentAccount {
            get => _currentAccount;
            set { 
                _currentAccount = value;
            } 
        }

        public bool isLoggedIn => _currentAccount != null;

      



    }
}
