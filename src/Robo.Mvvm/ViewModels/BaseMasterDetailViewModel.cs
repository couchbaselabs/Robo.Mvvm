using Robo.Mvvm.Services;

namespace Robo.Mvvm.ViewModels
{
    public abstract class BaseMasterDetailViewModel : BaseViewModel
    {
        INavigationService NavigationService { get; set; }

        public BaseViewModel Master { get; set; }

        BaseViewModel _detail;
        public BaseViewModel Detail
        {
            get => _detail;
            set
            {
                if (_detail != null)
                {
                    SetDetail(value);
                }

                _detail = value;
            }
        }

        protected BaseMasterDetailViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected BaseMasterDetailViewModel(INavigationService navigationService, BaseViewModel master, BaseViewModel detail)
                : this(navigationService)
        {
            Master = master;
            Detail = detail;
        }

        protected async void SetDetail(BaseViewModel viewModel) => await NavigationService.SetDetailAsync(viewModel);
    }
}
