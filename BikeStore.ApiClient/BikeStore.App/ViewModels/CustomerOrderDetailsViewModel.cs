using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.App.ViewModels
{
    public class CustomerOrderDetailsViewModel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region constructor
        public CustomerOrderDetailsViewModel(ICustomerApiClient customerApiClient)
        {
            _customerApiClient = customerApiClient;
            GetOrderCustomerOrderItemsLeftJoin();
        }
        
        #endregion

        #region Get Set

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
        #region Get customers , Orders and Order Items Left join - Method-2

        public async void GetOrderCustomerOrderItemsLeftJoin()
        {
            try
            {
                IsBusy = true;
                List<OrdersCustomersOrderItemsLeftJoin> leftJoinlist = await _customerApiClient.GetOrderCustomerAndOrderItemsLeftJoin();
                foreach (var item in leftJoinlist)
                {
                    item.FullNameChar = item.FullName.Substring(0, 1);
                    OrdersCustomersOrderItems.Add(item);

                }
                IsBusy= false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }


        #endregion
    }
}
