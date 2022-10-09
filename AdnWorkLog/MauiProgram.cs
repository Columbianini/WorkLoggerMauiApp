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

        return builder.Build();
	}
}
