using Engage.ChatGPT;
using Engage.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Engage.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            var homePageViewModel = new HomeViewModel();

            this.DataContext = homePageViewModel;
            this.InitializeComponent();
        }
    }
}
