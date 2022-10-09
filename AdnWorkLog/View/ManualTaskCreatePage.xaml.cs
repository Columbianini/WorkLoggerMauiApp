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
		await DisplayAlert("Future Dev Plan", "Please Navigate to the detailed page", "Ok");
	}

	private void OnNoClicked(object sender, EventArgs e)
	{
		TitleEntry.Text = "";
	}
}