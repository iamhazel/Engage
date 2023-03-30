// [FILE] Engage.ViewModels.ChatViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Engage.OpenAI;
using Engage.Models;

namespace Engage.ViewModels
{
    public class ChatViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly IChatService _chatService;

        public event PropertyChangedEventHandler PropertyChanged;

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTabIndex)));
            }
        }

        public CustomRelayCommand AddTabCommand { get; }
        public CustomRelayCommand CloseTabCommand { get; }

        private ObservableCollection<ChatTabViewModel> _tabs = new ObservableCollection<ChatTabViewModel>();
        public ObservableCollection<ChatTabViewModel> Tabs
        {
            get => _tabs;
            set
            {
                _tabs = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tabs)));
            }
        }

        // MessageTypeComboBox

        public ChatViewModel(IChatService chatService)
        {
            _chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));

            AddTab();
        }

        public void AddTab()
        {
            var tab = new ChatTabViewModel(_chatService, $"Tab {Tabs.Count + 1}");
            Tabs.Add(tab);
            SelectedTabIndex = Tabs.Count - 1;
        }

        public void CloseTab(object tabObj)
        {
            if (tabObj is ChatTabViewModel tab)
            {
                Tabs.Remove(tab);
            }
        }
    }
}
