using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class ProductNameForCategoryRightJoinPage : ContentPage
{
	public ProductNameForCategoryRightJoinPage(ProductNamePriceForCategoryRightJoinViewModel categoryRightJoinViewModel)
	{
		InitializeComponent();
		BindingContext= categoryRightJoinViewModel;
	}
}