using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdvanceNavigation.Services;
using AdvanceNavigation.Commands;

namespace AdvanceNavigation.ViewModels
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PersonViewModel> _people;

        public IEnumerable<PersonViewModel> People => _people;

        public ICommand AddPersonCommand { get;  }
        
        public PeopleListingViewModel(INavigationService addPersonNavigationService) {

            AddPersonCommand = new NavigateCommand(addPersonNavigationService);

            _people = new ObservableCollection<PersonViewModel>();

            _people.Add( new PersonViewModel("SingleSean") );
            _people.Add(new PersonViewModel("Mary"));
            _people.Add(new PersonViewModel("Joe"));

            Debug.WriteLine($"---------------- {_people}");

        }



    }
}
