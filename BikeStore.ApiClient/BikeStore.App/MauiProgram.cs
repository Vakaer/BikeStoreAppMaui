using BikeStore.ApiClient.ApiClients;
using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.App.ViewModels;
using BikeStore.App.Views;
using BikeStore.Data.Model;

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
            builder.Services.AddTransient<CustomerOrderDetailsViewModel>();
            builder.Services.AddSingleton<CustomersOrderDetails>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<OrderCountByProductNameViewModel>();
            builder.Services.AddSingleton<OrderCountPage>();
            builder.Services.AddSingleton<ProductNamePriceForCategoryRightJoinViewModel>();
            builder.Services.AddSingleton<ProductNameForCategoryRightJoinPage>();
            builder.Services.AddSingleton<StaffSelfjoinViewmodel>();
            builder.Services.AddSingleton<StaffSelfJoinPage>();
            builder.Services.AddSingleton<HighestDiscountViewModel>();
            builder.Services.AddSingleton<HighestDiscountPage>();



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