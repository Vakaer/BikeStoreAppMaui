using BikeStore.App.ViewModels;

namespace BikeStore.App.Views;

public partial class StaffSelfJoinPage : ContentPage
{
	public StaffSelfJoinPage(StaffSelfjoinViewmodel staffSelfjoinViewmodel)
	{
		InitializeComponent();
		BindingContext= staffSelfjoinViewmodel;
	}
}