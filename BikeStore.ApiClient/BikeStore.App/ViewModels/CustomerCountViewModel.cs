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
using Refit;


namespace BikeStore.App.ViewModels
{
    public class CustomerCountViewModel : INotifyPropertyChanged
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        public ICommand SeeTotalCustomersFromEachCity => new Command(GetCustomersCount);



        #endregion

        #region Get Set
        ObservableCollection<CustomerCountFromEachCity> Customers { get; set; } = new ObservableCollection<CustomerCountFromEachCity>();
        #endregion

        #region constructor
        public CustomerCountViewModel(ICustomerApiClient customerApiClient)
        {
            _customerApiClient = customerApiClient;
            GetCustomersCount();
        }
        #endregion

        public async void GetCustomersCount()
        {
             
            
   
            try
            {
                List<CustomerCountFromEachCity> customerList =await _customerApiClient.GetCustomersCity();
                 if (customerList != null)
                {
                    foreach(var item in customerList) 
                    { 
                        Customers.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            //return customers;
        }


        


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
