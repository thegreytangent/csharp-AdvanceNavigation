using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceNavigation.ViewModels
{
    public class LayoutViewModel: ViewModelBase
    {

        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ViewModelBase ContentViewModel { get; }

        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, ViewModelBase viewModelBase)
        {
            NavigationBarViewModel = navigationBarViewModel;
            this.ContentViewModel = viewModelBase;

           
        }


        public override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            ContentViewModel.Dispose();

            base.Dispose();
        }
    }
}
