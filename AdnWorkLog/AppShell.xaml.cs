using AdnWorkLog.View;

namespace AdnWorkLog;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DetailManualLog), typeof(DetailManualLog));
		Routing.RegisterRoute(nameof(MessageDetailPage), typeof(MessageDetailPage));
	}
}
