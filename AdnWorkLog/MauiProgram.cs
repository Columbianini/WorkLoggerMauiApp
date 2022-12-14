using AdnWorkLog.Model;
using AdnWorkLog.Services;
using AdnWorkLog.View;
using AdnWorkLog.ViewModel;
using CommunityToolkit.Maui;

namespace AdnWorkLog;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		
		builder.Services.AddSingleton<ManualTaskViewModel>();
        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailViewModel>();
		builder.Services.AddTransient<DetailManualLog>();
		builder.Services.AddTransient<MessageDetailViewModel>();
		builder.Services.AddTransient<MessageDetailPage>();

		string manualTaskRepoPath = FileAccessHelper.GetLocalFilePath("ManualTasks.db3");
		builder.Services.AddSingleton<ManualTaskRepository>(s => ActivatorUtilities.CreateInstance<ManualTaskRepository>(s, manualTaskRepoPath));

		string manualLogMessageRepoPath = FileAccessHelper.GetLocalFilePath("LogMessages.dbs3");
		builder.Services.AddSingleton<ManualLogMessageRepository>(s => ActivatorUtilities.CreateInstance<ManualLogMessageRepository>(s, manualLogMessageRepoPath));

        return builder.Build();
	}
}
