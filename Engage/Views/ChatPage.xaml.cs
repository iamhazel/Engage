// [FILE] Engage.Views.ChatPage.xaml.cs
using System;
using System.Diagnostics;
using Engage.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace Engage.Views
{
    public sealed partial class ChatPage : Page
    {
        private readonly ChatViewModel _viewModel;

        private int _tabCount = 0;
        private string _newMessageTextBoxValue;

        public ChatPage(ChatViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void ScrollToBottom()
        {
            ChatScrollViewer.ChangeView(null, ChatScrollViewer.ScrollableHeight, null);
        }

        private void NewMessageTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewMessageTextBox.Text))
            {
                MessageSendButton.IsEnabled = false;
            }
            else
            {
                MessageSendButton.IsEnabled = true;
            }
        }

        private void ChatTabView_AddTabButtonClick(TabView sender, object args)
        {
            _viewModel.AddTab();
        }

        private void ChatTabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            _viewModel.CloseTab(args.Item as ChatTabViewModel);
        }

        private void RoleSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleSelectionComboBox.SelectedIndex == 1)
            {
                ModelSelectionComboBox.IsEnabled = false;
            }
            else
            {
                ModelSelectionComboBox.IsEnabled = true;
            }
        }

        private void ChatTabView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                var oldTab = e.RemovedItems[0] as ChatTabViewModel;
                oldTab.MessageSent -= OnMessageSent;
                Debug.WriteLine("Unsubscribed from MessageSent event for oldTab");
            }

            if (e.AddedItems.Count > 0)
            {
                var newTab = e.AddedItems[0] as ChatTabViewModel;
                newTab.MessageSent += OnMessageSent;
                Debug.WriteLine("Subscribed to MessageSent event for newTab");
            }
        }

        private void OnMessageSent(object sender, EventArgs e)
        {
            Debug.WriteLine("OnMessageSent called");
            ScrollToBottom();
        }

        private void ScrollToBottomButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollToBottom();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _newMessageTextBoxValue = NewMessageTextBox.Text;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NewMessageTextBox.Text = _newMessageTextBoxValue;
        }

        private void TabClearMessages_Click(object sender, RoutedEventArgs e)
        {
            var selectedTab = ChatTabView.SelectedItem as ChatTabViewModel;
            selectedTab?.ClearMessages();
        }
    }
}