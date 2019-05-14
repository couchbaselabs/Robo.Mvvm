using Robo.Mvvm.Services;
using Robo.Mvvm.ViewModels;
using Xamarin.Forms;

namespace Robo.Mvvm.Forms.Pages
{
    public abstract class BaseContentPage : ContentPage
    {  }

    public abstract class BaseContentPage<T> : BaseContentPage, IViewFor<T> where T : BaseViewModel
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

        protected BaseContentPage()
        { }

        async void Init() => await ViewModel?.InitAsync();
    }
}
