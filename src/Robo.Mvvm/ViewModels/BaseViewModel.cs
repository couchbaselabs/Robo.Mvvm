using System.Threading.Tasks;
using Robo.Mvvm.Enumerations;

namespace Robo.Mvvm.ViewModels
{
    public abstract class BaseViewModel : BaseNotify
    {
        public ViewDisplayType ViewDisplay { get; set; } = ViewDisplayType.Default;

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetPropertyChanged(ref _isBusy, value);
        }

        public virtual Task InitAsync() => Task.FromResult(true);

        public static T GetViewModel<T>() where T : BaseViewModel
        {
           return ServiceContainer.GetInstance<T>();
        } 
    }
}
