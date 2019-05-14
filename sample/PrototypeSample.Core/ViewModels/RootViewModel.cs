using Robo.Mvvm.Services;
using Robo.Mvvm.ViewModels;

namespace PrototypeSample.Core.ViewModels
{
    public class RootViewModel : BaseMasterDetailViewModel
    {
        public RootViewModel(INavigationService navigationService) : base(navigationService)
        {
            var menuViewModel = GetViewModel<MenuViewModel>();
            menuViewModel.MenuItemSelected = MenuItemSelected;

            Master = menuViewModel;
           
            Detail = GetViewModel<CollectionViewModel>();
        }

        void MenuItemSelected(BaseViewModel viewModel) => SetDetail(viewModel);
    }
}
