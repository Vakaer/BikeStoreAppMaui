using BikeStore.App.Views;
using System.Windows.Input;

namespace BikeStore.App
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            Routes.Add("mainpage", typeof(MainPage));
            Routes.Add("customerorderdetails", typeof(CustomersOrderDetails));
            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}