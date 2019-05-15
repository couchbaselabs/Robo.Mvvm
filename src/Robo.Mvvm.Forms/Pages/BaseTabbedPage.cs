using System.Linq;
using Robo.Mvvm.Services;
using Robo.Mvvm.ViewModels;
using Xamarin.Forms;

namespace Robo.Mvvm.Forms.Pages
{
    public abstract class BaseTabbedPage : TabbedPage
    {  }

    public abstract class BaseTabbedPage<T> : BaseTabbedPage, IViewFor<T> where T : BaseCollectionViewModel
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
                _viewModel = value;

                UpdateBinding();
            }
        }

        object IViewFor.ViewModel
        {
            get => _viewModel;
            set => ViewModel = (T)value;
        }

        protected BaseTabbedPage()
        { }

        void UpdateBinding()
        {
            if (ViewModel != null)
            {
                BindingContext = ViewModel;

                ViewModel.PropertyChanged += OnPropertyChanged;

                Init();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (ViewModel != null)
            {
                ViewModel.PropertyChanged -= OnPropertyChanged;
            }
        }

        async void Init() => await ViewModel?.InitAsync();

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage != null)
            {
                var index = Children?.IndexOf(CurrentPage);

                if (ViewModel?.SelectedIndex != index && index.HasValue)
                {
                    ViewModel.SelectedIndex = index.Value;
                }
            }
        }

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (ViewModel != null)
            {
                if (e.PropertyName == nameof(ViewModel.SelectedIndex))
                {
                    SelectCurrentPageByIndex(ViewModel.SelectedIndex);
                }
                else if (e.PropertyName == nameof(ViewModel.SelectedViewModel))
                {
                    SelectCurrentPageByBaseViewModel(ViewModel.SelectedViewModel);
                }
            }
        }

        void SelectCurrentPageByIndex(int index)
        {
            if (index >= 0 && index <= Children?.Count)
            {
                CurrentPage = Children[index];
            }
        }

        void SelectCurrentPageByBaseViewModel(BaseViewModel viewModel)
        {
            if (Children?.Count > 0)
            {
                var page = Children.SingleOrDefault(x => ((x as NavigationPage)?.RootPage as IViewFor)?.ViewModel == viewModel);

                if (page != null)
                {
                    CurrentPage = page;
                }
            }
        }
    }
}
