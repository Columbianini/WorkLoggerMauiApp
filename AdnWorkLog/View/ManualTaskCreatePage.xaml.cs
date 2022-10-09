namespace AdnWorkLog.View;

public partial class ManualTaskCreatePage : ContentPage
{
	static Random _random = new();
	public ManualTaskCreatePage()
	{
		InitializeComponent();
	}

	async void OnYesClicked(object sender, EventArgs e)
	{
		// Shell.Current.GoToAsync()
		// Maybe create the related database here as well
		//await DisplayAlert("Future Dev Plan", "Please Navigate to the detailed page", "Ok");

		// TODO: Please Implement the method to create a new table with new Id in the database
		
		int Id = _random.Next(1, 10);
		await Shell.Current.GoToAsync($"{nameof(DetailManualLog)}?Id={Id}");
	}

	private void OnNoClicked(object sender, EventArgs e)
	{
		TitleEntry.Text = "";
	}
}