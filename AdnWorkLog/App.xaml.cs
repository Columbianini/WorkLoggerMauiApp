using AdnWorkLog.Services;

namespace AdnWorkLog;

public partial class App : Application
{
	public static ManualTaskRepository ManualTaskRepo { get; private set; }
	
	public static ManualLogMessageRepository ManualLogMessageRepo { get; private set; }
	
	public App(ManualTaskRepository manualTaskRepo, ManualLogMessageRepository manualLogMessageRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		ManualTaskRepo = manualTaskRepo;

		ManualLogMessageRepo = manualLogMessageRepo;

    }
}
