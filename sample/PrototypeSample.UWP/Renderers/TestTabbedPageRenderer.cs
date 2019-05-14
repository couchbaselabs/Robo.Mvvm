using PrototypeSample.Pages;
using PrototypeSample.UWP.Renderers;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(TestTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace PrototypeSample.UWP.Renderers
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            Control.TitleVisibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
