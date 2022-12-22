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

        #endregion

        #region constructor
        //public CustomerCountViewModel()
        //{
        //    GetCustomersCount();
        //}
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

        #region City name first Char 
        private ObservableCollection<string> _cityChar = new ObservableCollection<string>();
        public ObservableCollection<string> CityChar
        {
            get { return _cityChar; }
            set
            {
                _cityChar = value;
                OnPropertyChanged(nameof(CityChar));
            }
        }
        public void GetFirstNameChar()
        {
            try
            {
                foreach (var item in _customers)
                {
                    var city = item.City;
                    var res = city.Substring(0, 1);
                    CityChar.Add(res);
                }
            }
            catch(Exception ex) 
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            


        }
        #endregion


    }
}
