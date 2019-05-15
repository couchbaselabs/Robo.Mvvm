using System.Reflection;
using Robo.Mvvm.Services;
using Robo.Mvvm.ViewModels;

namespace Robo.Mvvm.Forms
{
    public static class App
    {
        static INavigationService NavigationService { get; set; }

        public static void Init(Assembly asm)
        {
            NavigationService = new NavigationService();
            NavigationService.AutoRegister(asm);

            ServiceContainer.Register(NavigationService);
        }

        public static void Init<T>(Assembly asm) where T : BaseViewModel
        {
            Init(asm);

            NavigationService?.SetRoot<T>(false);
        }
    }
}
