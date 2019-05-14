using PrototypeSample.Core.ViewModels;
using Xamarin.Forms;

namespace PrototypeSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Robo.Mvvm.Forms.App.Init<RootViewModel>(GetType().Assembly);
        }
    }
}
