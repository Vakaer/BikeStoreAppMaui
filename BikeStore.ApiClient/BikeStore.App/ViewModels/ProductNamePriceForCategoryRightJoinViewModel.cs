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
    public class ProductNamePriceForCategoryRightJoinViewModel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        public ICommand SeeTotalCustomersFromEachCity => new Command(GetCustomersCount);



        #endregion

        #region Get Set

      

        private ObservableCollection<ProductNamePriceForCategory> _productNamePriceForCategories = new ObservableCollection<ProductNamePriceForCategory>();
        public ObservableCollection<ProductNamePriceForCategory> ProductNamePriceForCategories
        {
            get
            {
                return _productNamePriceForCategories;
            }
            set
            {
                _productNamePriceForCategories = value;
                OnPropertyChanged(nameof(ProductNamePriceForCategories));
            }
        }

        #endregion

        #region constructor

        public ProductNamePriceForCategoryRightJoinViewModel(ICustomerApiClient customerApiClient)
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

                List<ProductNamePriceForCategory> categoryList = await _customerApiClient.GetProductAndCategoryRightJoin();
                if (categoryList != null)
                {
                    foreach (var item in categoryList)
                    {
                        item.CategoryNameChar = item.CategoryName.Substring(0, 1);
                        ProductNamePriceForCategories.Add(item);

                    }
                    IsBusy = false;
                    Debug.WriteLine(categoryList);
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
