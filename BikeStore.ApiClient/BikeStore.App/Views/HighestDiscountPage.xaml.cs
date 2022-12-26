using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class HighestDiscountPage : ContentPage
{
	public HighestDiscountPage(HighestDiscountViewModel discountViewModel)
	{
		InitializeComponent();
		BindingContext = discountViewModel;
	}
}