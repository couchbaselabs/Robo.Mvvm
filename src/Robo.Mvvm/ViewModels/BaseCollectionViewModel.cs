using System.Collections.Generic;

namespace Robo.Mvvm.ViewModels
{ 
    public abstract class BaseCollectionViewModel : BaseViewModel
    {
        public bool EnableNavigation { get; set; } = true;

        int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                SetPropertyChanged(ref _selectedIndex, value);
                _selectedViewModel = ViewModels[_selectedIndex];
            }
        }

        BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetPropertyChanged(ref _selectedViewModel, value);
                _selectedIndex = ViewModels.IndexOf(_selectedViewModel);
            }
        }

        public List<BaseViewModel> ViewModels { get; protected set; } = new List<BaseViewModel>();

        protected BaseCollectionViewModel(bool enableNavigation = true)
        {
            EnableNavigation = enableNavigation;
        }

        protected BaseCollectionViewModel(List<BaseViewModel> viewModels)
        {
            ViewModels = viewModels;
        }
    }
}
