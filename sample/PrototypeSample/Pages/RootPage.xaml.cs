using Robo.Mvvm.Forms.Pages;
using PrototypeSample.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace PrototypeSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : BaseMasterDetailPage<RootViewModel>
    {
        public RootPage()
        {
            InitializeComponent();
        }
    }
}
