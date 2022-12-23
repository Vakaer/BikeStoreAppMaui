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
    public class CustomerCountViewModel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        public ICommand SeeTotalCustomersFromEachCity => new Command(GetCustomersCount);



        #endregion

        #region Get Set

        private ObservableCollection<CustomerCountFromEachCity> _customers = new ObservableCollection<CustomerCountFromEachCity>();
        public ObservableCollection<CustomerCountFromEachCity> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        private ObservableCollection<OrdersCustomersOrderItemsLeftJoin> _ordersCustomersOrderItems = new ObservableCollection<OrdersCustomersOrderItemsLeftJoin>();
        public ObservableCollection<OrdersCustomersOrderItemsLeftJoin> OrdersCustomersOrderItems
        {
            get
            {
                return _ordersCustomersOrderItems;
            }
            set
            {
                _ordersCustomersOrderItems = value;
                OnPropertyChanged(nameof(OrdersCustomersOrderItems));
            }
        }

        #endregion

        #region constructor

        public CustomerCountViewModel(ICustomerApiClient customerApiClient)
        {
            _customerApiClient = customerApiClient;
            GetCustomersCount();
        }
        #endregion

        #region Get customers count from each city - Method-1
        public async void GetCustomersCount()
        {
            try
            {
                List<CustomerCountFromEachCity> customerList = await _customerApiClient.GetCustomersCity();
                if (customerList != null)
                {
                    foreach (var item in customerList)
                    {
                        item.CityChar = item.City.Substring(0, 1);
                        Customers.Add(item);
                         
                    }
                    Debug.WriteLine(customerList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            //return customers;
        }

       


    }
}
#endregion