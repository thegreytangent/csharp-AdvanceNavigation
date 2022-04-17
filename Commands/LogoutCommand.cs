﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceNavigation.Stores;

namespace AdvanceNavigation.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly AccountStore _accountStore;

        public LogoutCommand(AccountStore accountStore) { 
            _accountStore = accountStore;
        }

        public override void Execute(object parameter)
        {

            _accountStore.Logout();
        }
    }
}
