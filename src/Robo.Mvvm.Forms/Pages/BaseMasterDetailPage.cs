using System;
using System.Threading.Tasks;
using Robo.Mvvm.Services;
using Robo.Mvvm.ViewModels;
using Xamarin.Forms;

namespace Robo.Mvvm.Forms.Pages
{
    public class BaseMasterDetailPage : MasterDetailPage
    { }

    public class BaseMasterDetailPage<T> : BaseMasterDetailPage, IViewFor<T> where T : BaseViewModel
    {
        T _viewModel;

        public T ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                BindingContext = _viewModel = value;
                Init();
            }
        }

        object IViewFor.ViewModel
        {
            get => _viewModel;
            set => ViewModel = (T)value;
        }

        async void Init() => await ViewModel?.InitAsync();
    }
}
