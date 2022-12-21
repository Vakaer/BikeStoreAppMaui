using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.Data.Model;
using ThreadNetwork;


namespace BikeStore.App.ViewModels
{
    public class CustomerCountViewModel : INotifyPropertyChanged
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        //public ICommand SeeTotalCustomersFromEachCity => new Command(GetCustomersCount);



        #endregion
       
        public CustomerCountViewModel(ICustomerApiClient customerApiClient)
        {
            _customerApiClient = customerApiClient;
            GetCustomersCount();
        }

        public async void GetCustomersCount()
        {
            ObservableCollection<CustomerCountFromEachCity> customers = new ObservableCollection<CustomerCountFromEachCity>();

   
            try
            {
                 var customerList =  _customerApiClient.GetCustomersCity();
                 if (customerList != null)
                {
                    string content = customerList.ToString();
                    customers = JsonSerializer.Deserialize<ObservableCollection<CustomerCountFromEachCity>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            //return customers;
        }

        ObservableCollection<CustomerCountFromEachCity> _customers;

        public ObservableCollection<CustomerCountFromEachCity> Customers
        {
            get { return _customers; }
            set
            {
                if (value != null)
                {
                    _customers = value;
                    OnPropertyChanged();
                }




            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
