﻿using BikeStore.ApiClient.ApiClients.Interfaces;
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
    public class HighestDiscountViewModel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        public ICommand GetNthHighestDiscount => new Command(GetCustomersCount);



        #endregion

        #region Get Set

        //for entry
        private int _highestDiscount;
        public int HighestDiscount
        {
            get => _highestDiscount;
            set
            {
                _highestDiscount = value;
                OnPropertyChanged(nameof(HighestDiscount));
            }
        }
        //for label
        private HighestDiscount _highestDiscounts;
        public HighestDiscount HighestDiscountValue
        {
            get
            {
                return _highestDiscounts;
            }
            set
            {
                _highestDiscounts = value;
                OnPropertyChanged(nameof(HighestDiscountValue));
            }
        }

        #endregion

        #region constructor

        public HighestDiscountViewModel(ICustomerApiClient customerApiClient)
        {
            _customerApiClient = customerApiClient;
        }
        #endregion

        #region Get customers count from each city - Method-1
        public async void GetCustomersCount()
        {
            try
            {

                HighestDiscount discounts = await _customerApiClient.GetHighestDiscount(HighestDiscount);
                IsBusy = false;
                if (discounts != null)
                {
                    HighestDiscountValue.Discount = discounts.Discount;
                    
                    Debug.WriteLine(discounts);
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
