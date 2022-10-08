using AdnWorkLog.ViewModel;

namespace AdnWorkLog.View;

public partial class MainPage : ContentPage
{
	public MainPage(ManualTaskViewModel manualTaskViewModel)
	{
		InitializeComponent();
		BindingContext = manualTaskViewModel;
	}
}