using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceNavigation.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public string Name { get;  }

        public PersonViewModel(string _name) {
            Name = _name;
        }


    }
}
