// Engage.Views.Controls.Signal.xaml.cs
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;

using Windows.UI.Xaml;

namespace Engage.Views.Controls
{
    public sealed partial class Signal : Page
    {
        // PROPERTIES
        public enum SignalType
        {
            Success,
            Caution,
            Critical,
            Attention
        }
        public string Title { get; set; }
        public bool IsClosable { get; set; }
        public bool IsIconVisible { get; set; }
        public string Message { get; set; }
        public SignalType Type { get; set; }
        public string ActionContent { get; set; }

        public event RoutedEventHandler SignalActionClick;

        // CONSTRUCTOR
        public Signal()
        {
            this.InitializeComponent();
        }

        // METHODS
        public void SetSignalClickHandler(RoutedEventHandler handler)
        {
            SignalActionClick += handler;
        }

        private void Signal_Click(object sender, RoutedEventArgs e)
        {
            SignalActionClick?.Invoke(sender, e);
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}