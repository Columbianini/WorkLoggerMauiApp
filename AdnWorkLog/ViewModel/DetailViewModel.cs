using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdnWorkLog.Model;
using CommunityToolkit.Mvvm.Input;
using AdnWorkLog.View;

namespace AdnWorkLog.ViewModel
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class DetailViewModel: ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ManualLogMessageList))]
        int id;

        [ObservableProperty]
        string titleFromTitleId;

        async partial void OnIdChanged(int value)
        {
            if (ManualLogMessageList.Count > 0)
            {
                ManualLogMessageList.Clear();
            }
            await RefreshLogMessageList();
            await RefreshTitleFromId();
        }


        public ObservableCollection<ManualLogMessage> ManualLogMessageList { get;set; }

        public DetailViewModel()
        {
            ManualLogMessageList = new();
        }

        [RelayCommand]
        public async Task AddMessage(IEntry entry)
        {
           string message = entry.Text;
           int result = await App.ManualLogMessageRepo.AddNewLogMessage(message);
           if(result == -1)
            {
                await App.Current.MainPage.DisplayAlert("Error", App.ManualLogMessageRepo.StatusMessage, "Ok");
            }
            else
            {
                await RefreshLogMessageList();
                entry.Text = "";
            }

        }

        [RelayCommand]
        async Task CheckDetails(ManualLogMessage message)
        {
            await Shell.Current.GoToAsync(nameof(MessageDetailPage), true, new Dictionary<string, object>()
            {
                {"Message", message }
            });
        }


        [RelayCommand]
        async Task RefreshLogMessageList()
        {
            List<ManualLogMessage> logMessageListFromDb = await App.ManualLogMessageRepo.GetLogMessagesById(id);
            if (ManualLogMessageList.Count > 0)
            {
                ManualLogMessageList.Clear();
            }
            foreach (var logMessage in logMessageListFromDb)
            {
                ManualLogMessageList.Add(logMessage);
            }
        }

        async Task RefreshTitleFromId()
        {
            this.TitleFromTitleId = await App.ManualTaskRepo.GetTitleById(this.Id);
        }

    }
}
