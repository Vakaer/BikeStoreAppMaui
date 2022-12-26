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
    public class StaffSelfjoinViewmodel : BaseViewModel
    {
        #region private Properties

        private ICustomerApiClient _customerApiClient;

        #endregion

        #region Commands 
        public ICommand SeeTotalCustomersFromEachCity => new Command(GetCustomersCount);



        #endregion

        #region Get Set



        private ObservableCollection<StaffSelfJoin> _staffSelfJoin = new ObservableCollection<StaffSelfJoin>();
        public ObservableCollection<StaffSelfJoin> StaffSelfJoin
        {
            get
            {
                return _staffSelfJoin;
            }
            set
            {
                _staffSelfJoin = value;
                OnPropertyChanged(nameof(StaffSelfJoin));
            }
        }

        #endregion

        #region constructor

        public StaffSelfjoinViewmodel(ICustomerApiClient customerApiClient)
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

                List<StaffSelfJoin> staffList = await _customerApiClient.GetStaffSelfJoin();
                if (staffList != null)
                {
                    foreach (var item in staffList)
                    {
                        item.StaffNameChar = item.StaffName.Substring(0, 1);
                        StaffSelfJoin.Add(item);

                    }
                    IsBusy = false;
                    Debug.WriteLine(staffList);
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
