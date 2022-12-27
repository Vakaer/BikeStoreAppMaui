using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class OrderForProductNamePriceIDPage : ContentPage
{
	public OrderForProductNamePriceIDPage(OrderForProductNamePriceIDViewModel orderForProductName)
	{
		InitializeComponent();
		BindingContext= orderForProductName;
	}
}