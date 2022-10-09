using AdnWorkLog.ViewModel;

namespace AdnWorkLog.View;

public partial class DetailManualLog : ContentPage
{
	public DetailManualLog(DetailViewModel detailViewModel)
	{
		InitializeComponent();
		BindingContext = detailViewModel;
	}
}