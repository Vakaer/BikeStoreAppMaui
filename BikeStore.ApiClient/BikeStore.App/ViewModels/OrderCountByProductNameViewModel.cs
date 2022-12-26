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
    public class OrderCountByProductNameViewModel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region constructor
        public OrderCountByProductNameViewModel(ICustomerApiClient customerApiClient)
        {
            _customerApiClient = customerApiClient;
            GetOrderCustomerOrderItemsLeftJoin();
        }

        #endregion

        #region Get Set

        private ObservableCollection<OrderCountByProduct> _orderCountByProducts = new ObservableCollection<OrderCountByProduct>();
        public ObservableCollection<OrderCountByProduct> OrderCountByProducts
        {
            get
            {
                return _orderCountByProducts;
            }
            set
            {
                _orderCountByProducts = value;
                OnPropertyChanged(nameof(OrderCountByProducts));
            }
        }

        #endregion
        #region Get customers , Orders and Order Items Left join - Method-2

        public async void GetOrderCustomerOrderItemsLeftJoin()
        {
            try
            {
                List<OrderCountByProduct> leftJoinlist = await _customerApiClient.GetTotalOrdersAgainstEachProduct();
                foreach (var item in leftJoinlist)
                {
                    item.ProductNameChar = item.ProductName.Substring(0, 1);
                    OrderCountByProducts.Add(item);

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
