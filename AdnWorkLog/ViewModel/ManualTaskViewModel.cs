using AdnWorkLog.Model;
//using Android.OS;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.ViewModel
{
    public partial class ManualTaskViewModel: ObservableObject
    {
        public ObservableCollection<ManualTask> ManualTasks { get; set; }

        public ManualTaskViewModel()
        {
            ManualTasks = new ObservableCollection<ManualTask>
            {
                new ManualTask(1, "Write Code", new DateTime(2022, 10, 8, 21, 26, 0)),
                new ManualTask(2, "Write Code", new DateTime(2022, 10, 8, 22, 26, 0)),
                new ManualTask(3, "Write Code", new DateTime(2022, 10, 8, 21, 26, 0)),
                new ManualTask(4, "Write Code", new DateTime(2022, 10, 7, 21, 2, 0)),
                new ManualTask(5, "Write Code", new DateTime(2022, 10, 8, 21, 6, 0)),
                new ManualTask(6, "Write Code", new DateTime(2022, 10, 8, 1, 26, 0)),
                new ManualTask(7, "Write Code", new DateTime(2022, 1, 8, 21, 26, 0)),
            };
        }

        // TODO: Add a SwipeView with Delete/Edit button https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/swipeview
        [RelayCommand]
        public void DeleteManualTaskById(int Id)
        {
            Debug.WriteLine("Please Implement the Part to Delete he Manual Task: check whether DataBinding worked");
        }

        [RelayCommand]
        public void EditManualTaskById(int Id)
        {
            Debug.WriteLine("Please Implement the Part to Edit the Manual Task: check whether it will go");
        }

    }
}
