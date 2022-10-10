namespace AdnWorkLog.View;

public partial class ManualTaskCreatePage : ContentPage
{
	public ManualTaskCreatePage()
	{
		InitializeComponent();
	}

	async void OnYesClicked(object sender, EventArgs e)
	{
		// Shell.Current.GoToAsync()
		// Maybe create the related database here as well
		//await DisplayAlert("Future Dev Plan", "Please Navigate to the detailed page", "Ok");

		// TODO: Please Implement the method to create a new table with new Id in the databasetry{try{
		
        int result = await App.ManualTaskRepo.AddNewManualTask(TitleEntry.Text);
		if(result == -1)
		{
			await DisplayAlert("Error", App.ManualTaskRepo.StatusMessage, "ok");
		}
		else
		{
            await Shell.Current.GoToAsync($"{nameof(DetailManualLog)}?Id={result}");
        }
	}

	private void OnNoClicked(object sender, EventArgs e)
	{
		TitleEntry.Text = "";
	}
}