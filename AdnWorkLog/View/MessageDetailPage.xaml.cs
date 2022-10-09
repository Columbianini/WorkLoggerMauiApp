using AdnWorkLog.ViewModel;

namespace AdnWorkLog.View;

public partial class MessageDetailPage : ContentPage
{
	public MessageDetailPage(MessageDetailViewModel messageDetailViewModel)
	{
		InitializeComponent();
		BindingContext = messageDetailViewModel;	
	}
}