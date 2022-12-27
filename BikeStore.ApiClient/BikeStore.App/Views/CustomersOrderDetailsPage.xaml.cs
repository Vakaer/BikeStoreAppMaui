using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class CustomersOrderDetailsPage : ContentPage
{
	public CustomersOrderDetailsPage(CustomerOrderDetailsViewModel customerOrderDetails)
	{
		InitializeComponent();
		BindingContext= customerOrderDetails;
	}
}