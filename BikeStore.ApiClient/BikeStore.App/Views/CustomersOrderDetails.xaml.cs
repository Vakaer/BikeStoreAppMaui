using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class CustomersOrderDetails : ContentPage
{
	public CustomersOrderDetails(CustomerOrderDetailsViewModel customerOrderDetails)
	{
		InitializeComponent();
		BindingContext= customerOrderDetails;
	}
}