using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class OrderCountPage : ContentPage
{
	public OrderCountPage(OrderCountByProductNameViewModel orderCountByProduct)
	{
		InitializeComponent();
		BindingContext= orderCountByProduct;
	}
}