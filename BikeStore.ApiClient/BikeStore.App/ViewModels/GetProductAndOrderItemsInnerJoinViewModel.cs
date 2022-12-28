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
    public class GetProductAndOrderItemsInnerJoinViewModel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        public ICommand SeeTotalCustomersFromEachCity => new Command(GetCustomersCount);



        #endregion

        #region Get Set



        private ObservableCollection<ProductAndOrderItems> _productAndOrderItems = new ObservableCollection<ProductAndOrderItems>();
        public ObservableCollection<ProductAndOrderItems> ProductAndOrderItems
        {
            get
            {
                return _productAndOrderItems;
            }
            set
            {
                _productAndOrderItems = value;
                OnPropertyChanged(nameof(ProductAndOrderItems));
            }
        }

        #endregion

        #region constructor

        public GetProductAndOrderItemsInnerJoinViewModel(ICustomerApiClient customerApiClient)
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
                List<ProductAndOrderItems> productList = await _customerApiClient.GetProductAndOrderItemsInnerJoin();
                if (productList != null)
                {
                    foreach (var item in productList)
                    {
                        item.ProductNameChar = item.ProductName.Substring(0, 1);
                        ProductAndOrderItems.Add(item);

                    }
                    IsBusy = false;
                    Debug.WriteLine(productList);
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
