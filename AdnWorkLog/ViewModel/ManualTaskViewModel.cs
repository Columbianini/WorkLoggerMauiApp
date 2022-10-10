using AdnWorkLog.Model;
using AdnWorkLog.View;
//using Android.OS;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.ViewModel
{
    public partial class ManualTaskViewModel: ObservableObject
    {
        public ObservableCollection<ManualTask> ManualTasks { get; set; } = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotRefreshing))]
        bool isRefreshing;

        public bool IsNotRefreshing => !isRefreshing;



        public ManualTaskViewModel()
        {
            isRefreshing = false;
        }


        [RelayCommand]
        async Task GetAllManualTasks()
        {


            if (!isRefreshing)
            {
                try
                {
                    isRefreshing = true;
                    List<ManualTask> manualTasksFromDb = await App.ManualTaskRepo.GetAllManualTasks();
                    if (ManualTasks.Count > 0)
                    {
                        ManualTasks.Clear();
                    }
                    foreach (var manualTask in manualTasksFromDb)
                    {
                        ManualTasks.Add(manualTask);
                    }
                    if (ManualTasks.Count == 0)
                    {
                        await App.Current.MainPage.DisplayAlert("Warning", App.ManualTaskRepo.StatusMessage, "Ok");
                    }
                }
                catch(Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", $"Fail to Get Manual Tasks From Db: {ex.Message}", "Ok");
                }
                finally
                {
                    isRefreshing = false;
                }        
            }
        }

        // TODO: Add a SwipeView with Delete/Edit button https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/swipeview
        [RelayCommand]
        async Task DeleteManualTaskById(int Id)
        {
            // https://social.msdn.microsoft.com/Forums/en-US/7f19554f-77fb-41e8-8723-96e0ac7b189e/how-to-use-displayalert-from-a-viewmodel-without-additional-frameworks?forum=xamarinforms
            if (await Application.Current.MainPage.DisplayAlert("Warning", "Do you want to permanently delete?", "Yes", "No"))
            {
                List<ManualTask> updateManualTasks = ManualTasks.Where(e => e.Id != Id).ToList<ManualTask>();
                ManualTasks.Clear();
                foreach (var manualTask in updateManualTasks)
                {
                    ManualTasks.Add(manualTask);
                }

                int result = await App.ManualTaskRepo.DeleteManualTask(Id);
                if (result == -1)
                {
                    await App.Current.MainPage.DisplayAlert("Error", App.ManualTaskRepo.StatusMessage, "Ok");
                }
            }  
        }

        [RelayCommand]
        async Task CheckManualTaskById(int Id)
        {
            // TODO: Here the Id is actually TitleId, please Refactor the code later
            await Shell.Current.GoToAsync($"{nameof(DetailManualLog)}?Id={Id}");
        }

    }
}
