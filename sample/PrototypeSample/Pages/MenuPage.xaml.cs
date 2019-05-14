using Robo.Mvvm.Forms.Pages;
using PrototypeSample.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototypeSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : BaseContentPage<MenuViewModel>
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}
