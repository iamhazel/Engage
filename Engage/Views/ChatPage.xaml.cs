// [FILE] Engage.Views.ChatPage.xaml.cs
using Engage.ChatGPT;
using Engage.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Core;
using Windows.System;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

namespace Engage.Views
{
    public sealed partial class ChatPage : Page
    {
        public ChatViewModel ViewModel => (ChatViewModel)DataContext;

        public DependencyObject ChatBorder { get; private set; }

        public ChatPage(IService chatService)
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).ChatViewModel;
            ViewModel.ChatService = chatService; // Pass the IService instance to the ChatViewModel
            MessageTypeComboBox.SelectionChanged += MessageTypeComboBox_SelectionChanged;
        }

        private void MessageTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel.InputMessageSource = MessageTypeComboBox.SelectedIndex == 0 ? "user" : "assistant";
            }
        }

        private void ChatTabView_AddTabButtonClick(TabView sender, object args)
        {
            var newTab = new TabViewItem
            {
                Header = "Chat " + (ChatTabView.TabItems.Count + 1)
            };
            ChatTabView.TabItems.Add(newTab);
            ChatTabView.SelectedItem = newTab;
        }

        private void ChatTabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
        }
    }
}