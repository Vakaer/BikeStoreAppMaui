using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class GetProductAndOrderItemsInnerJoinPage : ContentPage
{
	public GetProductAndOrderItemsInnerJoinPage(GetProductAndOrderItemsInnerJoinViewModel itemsInnerJoinViewModel)
	{
		InitializeComponent();
		BindingContext= itemsInnerJoinViewModel;
	}
}