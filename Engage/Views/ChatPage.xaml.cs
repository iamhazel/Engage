// [FILE] Engage.Views.ChatPage.xaml.cs
using Engage.ChatGPT;
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