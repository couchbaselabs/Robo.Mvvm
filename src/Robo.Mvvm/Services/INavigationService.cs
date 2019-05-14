using System;
using System.Reflection;
using System.Threading.Tasks;
using Robo.Mvvm.ViewModels;

namespace Robo.Mvvm.Services
{
    public interface INavigationService
    {
        void AutoRegister(Assembly asm);
        void Register(Type viewModelType, Type viewType);
        Task PopAsync(bool animated = true);
        Task PopModalAsync(bool animated = true);
        Task PushAsync(BaseViewModel viewModel);
        Task PushModalAsync(BaseViewModel viewModel, bool nestedNavigation = false);
        Task PopToRootAsync(bool animated = true);
        Task SetDetailAsync(BaseViewModel viewModel, bool allowSamePageSet = false);
        void SetRoot<T>(bool withNavigationEnabled = true) where T : BaseViewModel;
        void SetRoot(BaseViewModel viewModel, bool withNavigationEnabled = true);
    }
}
