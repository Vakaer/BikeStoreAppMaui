using BikeStore.ApiClient.ApiClients;
using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.App.ViewModels;

namespace BikeStore.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder.Services.AddSingleton<HttpClientProvider>();
            builder.Services.AddSingleton<ICustomerApiClient, CustomerApiClient>();
            builder.Services.AddSingleton<CustomerCountViewModel>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();


            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            


            return builder.Build();
        }
    }
}