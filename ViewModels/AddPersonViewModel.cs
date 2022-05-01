using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AdvanceNavigation.ViewModels
{
    public class AddPersonViewModel : ViewModelBase
    {
        private string _name;

        public string Name { 
            get { return _name; } 
            set { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand SubmitCommand { get;  }
        public ICommand CancelCommand { get;  }

        public AddPersonViewModel() { 
            
        }

    }
}
