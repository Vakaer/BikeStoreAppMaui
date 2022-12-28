using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BikeStore.App.ViewModels
{
    public class OrderForProductNamePriceIDViewModel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        public ICommand SeeTotalCustomersFromEachCity => new Command(GetCustomersCount);



        #endregion

        #region Get Set



        private ObservableCollection<OrderForProductNamePriceID> _orderForProducts = new ObservableCollection<OrderForProductNamePriceID>();
        public ObservableCollection<OrderForProductNamePriceID> OrderForProducts
        {
            get
            {
                return _orderForProducts;
            }
            set
            {
                _orderForProducts = value;
                OnPropertyChanged(nameof(OrderForProducts));
            }
        }

        #endregion

        #region constructor

        public OrderForProductNamePriceIDViewModel(ICustomerApiClient customerApiClient)
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
                IsBusy = true;
                List<OrderForProductNamePriceID> orderList = await _customerApiClient.OrderForProductNamePriceID();
                if (orderList != null)
                {
                    foreach (var item in orderList)
                    {
                        item.ProductNameChar = item.ProductName.Substring(0, 1);
                        
                        OrderForProducts.Add(item);

                    }
                    IsBusy = false;
                    Debug.WriteLine(orderList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


        }
        #endregion
    }
}
