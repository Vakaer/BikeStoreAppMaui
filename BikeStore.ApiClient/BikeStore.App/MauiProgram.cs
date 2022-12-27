using BikeStore.ApiClient.ApiClients;
using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.App.ViewModels;
using BikeStore.App.Views;

namespace BikeStore.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddSingleton<HttpClientProvider>();
            builder.Services.AddSingleton<ICustomerApiClient, CustomerApiClient>();

            builder.Services.AddSingleton<AppShell>();
            //resolving services for Method-1
            builder.Services.AddSingleton<CustomerCountViewModel>();
            builder.Services.AddSingleton<MainPage>();
            //resolving services for Method-2
            builder.Services.AddSingleton<CustomerOrderDetailsViewModel>();
            builder.Services.AddSingleton<CustomersOrderDetailsPage>();
            //resolving services for Method-3
            builder.Services.AddSingleton<OrderCountByProductNameViewModel>();
            builder.Services.AddSingleton<OrderCountPage>();
            //resolving services for Method-4
            builder.Services.AddSingleton<ProductNamePriceForCategoryRightJoinViewModel>();
            builder.Services.AddSingleton<ProductNameForCategoryRightJoinPage>();
            //resolving services for Method-5
            builder.Services.AddSingleton<StaffSelfjoinViewmodel>();
            builder.Services.AddSingleton<StaffSelfJoinPage>();
            //resolving services for Method-6
            builder.Services.AddSingleton<GetProductAndOrderItemsInnerJoinViewModel>();
            builder.Services.AddSingleton<GetProductAndOrderItemsInnerJoinPage>();
            //resolving services for Method-7
            builder.Services.AddSingleton<HighestDiscountViewModel>();
            builder.Services.AddSingleton<HighestDiscountPage>();
            //resolving services for Method-8
            builder.Services.AddSingleton<OrderForProductNamePriceIDViewModel>();
            builder.Services.AddSingleton<OrderForProductNamePriceIDPage>();



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