using AdnWorkLog.Services;

namespace AdnWorkLog;

public partial class App : Application
{
	public static ManualTaskRepository ManualTaskRepo { get; private set; }
	public App(ManualTaskRepository manualTaskRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		ManualTaskRepo = manualTaskRepo;

    }
}
