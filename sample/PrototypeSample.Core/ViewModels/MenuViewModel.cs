using System;
using System.Collections.Generic;
using System.Windows.Input;
using Robo.Mvvm.Input;
using Robo.Mvvm.ViewModels;

namespace PrototypeSample.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public Action<BaseViewModel> MenuItemSelected { get; set; }

        public List<string> MenuItems { get; set; }

        ICommand _menuItemSelectedCommand;
        public ICommand MenuItemSelectedCommand
        {
            get
            {
                if (_menuItemSelectedCommand == null)
                {
                    _menuItemSelectedCommand = new Command<string>(OnMenuItemSelectedAsync);
                }

                return _menuItemSelectedCommand;
            }
        }

        public MenuViewModel() => LoadMenuItems();

        void LoadMenuItems()
        {
            MenuItems = new List<string>(new[]
            {
                "Tabbed Page",
                "Page 1",
                "Page 2",
                "Page 3"
            });
        }

        void OnMenuItemSelectedAsync(string item)
        {
            BaseViewModel viewModel = null;

            switch(item)
            {
                case "Tabbed Page":
                    viewModel = GetViewModel<CollectionViewModel>();
                    break;
                case "Page 1":
                    viewModel = GetViewModel<ViewModel1>();
                    break;
                case "Page 2":
                    viewModel = GetViewModel<ViewModel2>();
                    break;
                case "Page 3":
                    viewModel = GetViewModel<ViewModel3>();
                    break;
            }

            if (viewModel != null)
            {
                MenuItemSelected(viewModel);
            }
        }
    }
}
