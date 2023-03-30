using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

namespace Engage.Views.Controls
{
    public sealed partial class Alert : UserControl
    {
        public Alert()
        {
            this.InitializeComponent();
            this.Loaded += Alert_Loaded;
            CloseAlertButton.Click += CloseAlertButton_Click;
        }

        private void Alert_Loaded(object sender, RoutedEventArgs e)
        {
            this.CloseAlertButton.Click += CloseAlertButton_Click;
        }

        private void CloseAlertButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

    }
}