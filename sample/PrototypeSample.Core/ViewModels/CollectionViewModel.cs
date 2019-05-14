using System.Windows.Input;
using Robo.Mvvm.Input;
using Robo.Mvvm.ViewModels;

namespace PrototypeSample.Core.ViewModels
{
    public class CollectionViewModel : BaseCollectionViewModel
    {
        ICommand _switchCommand;
        public ICommand SwitchCommand
        {
            get
            {
                if (_switchCommand == null)
                {
                    _switchCommand = new Command(SwitchSelected);
                }

                return _switchCommand;
            }
        }

        public CollectionViewModel() //: base(false)
        {
            ViewModels.Add(GetViewModel<ViewModel1>());
            ViewModels.Add(GetViewModel<ViewModel2>());
        }

        void SwitchSelected()
        {
            var newIndex = SelectedIndex == 0 ? 1 : 0;

            // You can change the selected item by updating the

            // 1.) SelectedViewModel
            //SelectedViewModel = ViewModels[newIndex];

            // 2.) SelectedIndex
            SelectedIndex = newIndex;
        }
    }
}
