using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdnWorkLog.Model;
using CommunityToolkit.Mvvm.Input;

namespace AdnWorkLog.ViewModel
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class DetailViewModel: ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ManualLogMessageList))]
        int id;

        partial void OnIdChanged(int value)
        {
            if (ManualLogMessageList.Count > 0)
            {
                ManualLogMessageList.Clear();
            }

            ManualLogMessageList.Add(new ManualLogMessage(new DateTime(2001, 1, 1, 10, 0, 0), $"Wake up {value}"));
            ManualLogMessageList.Add(new ManualLogMessage(new DateTime(2001, 1, 2, 11, 0, 0), $"Lunch Break {value}"));
        }


        public ObservableCollection<ManualLogMessage> ManualLogMessageList { get;set; }

        public DetailViewModel()
        {
            ManualLogMessageList = new();
        }

        [RelayCommand]
        public void AddMessage(string message)
        {
            ManualLogMessageList.Add(new ManualLogMessage(DateTime.Now, message));
        }
    }
}
