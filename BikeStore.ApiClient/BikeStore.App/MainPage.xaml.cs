using BikeStore.App.ViewModels;

namespace BikeStore.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage( CustomerCountViewModel customerCountViewModel)
        {
            InitializeComponent();
            BindingContext = customerCountViewModel;
        }

       
    }
}