// [FILE] Engage.Views.ChatPage.xaml.cs
using Engage.ChatGPT;
using Engage.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
namespace Engage.Views
{
    public sealed partial class ChatPage : Page
    {
        private readonly ChatViewModel _viewModel;
        private int _tabCount = 0;

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

        // If the text box is empty, disable the send button
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
    }
}