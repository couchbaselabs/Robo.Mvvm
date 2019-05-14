using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Robo.Mvvm.Input;
using Robo.Mvvm.Services;
using Robo.Mvvm.ViewModels;

namespace PrototypeSample.Core.ViewModels
{
    public class ViewModel3 : BaseViewModel
    {
        INavigationService Navigation { get; set; }

        ICommand _dismissCommand;
        public ICommand DismissCommand
        {
            get
            {
                if (_dismissCommand == null)
                {
                    _dismissCommand = new Command(async () => await DismissAsync());
                }

                return _dismissCommand;
            }
        }

        ICommand _navigationCommand;
        public ICommand NavigationCommand
        {
            get
            {
                if (_navigationCommand == null)
                {
                    _navigationCommand = new Command(async () => await Navigation.PushAsync(GetViewModel<CollectionViewModel>()));
                }

                return _navigationCommand;
            }
        }

        public ViewModel3(INavigationService navigation)
        {
            Navigation = navigation;
        }

        Task DismissAsync()
        {
            if (ViewDisplay == Robo.Mvvm.Enumerations.ViewDisplayType.Modal)
            {
                return Navigation.PopModalAsync();
            }

            return Navigation.PopAsync();
        }
    }
}
