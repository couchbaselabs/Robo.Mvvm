using System.Windows.Input;
using Robo.Mvvm.Input;
using Robo.Mvvm.Services;
using Robo.Mvvm.ViewModels;

namespace PrototypeSample.Core.ViewModels
{
    public class ViewModel2 : BaseViewModel
    {
        INavigationService Navigation { get; set; }

        ICommand _navigationCommand;
        public ICommand NavigationCommand
        {
            get
            {
                if (_navigationCommand == null)
                {
                    _navigationCommand = new Command(async () => await Navigation.PushModalAsync(GetViewModel<ViewModel3>()));
                }

                return _navigationCommand;
            }
        }

        public ViewModel2(INavigationService navigationService)
        {
            Navigation = navigationService;
        }
    }
}
