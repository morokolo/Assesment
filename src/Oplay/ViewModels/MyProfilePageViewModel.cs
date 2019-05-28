using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using Oplay.Services.Implementations;
using Oplay.Models.Response;
using Oplay.Constants;

namespace Oplay.ViewModels
{
    public class MyProfilePageViewModel :  ViewModelBase, INavigatedAware
    {
        public EmployeeResponse EmployeeDetail { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime dob { get; set; }
        public int id { get; set; }

        public MyProfilePageViewModel(INavigationService navigationService, Services.Interfaces.IStorageHelper storageHelper, IPageDialogService pageDialogService) : base(navigationService, storageHelper, pageDialogService)
        {
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
       
            await Task.Delay(1000);
            EmployeeDetail = GetEmployeeDetailDataFromNavParameters(parameters);
            firstname = EmployeeDetail.firstName;
            lastname = EmployeeDetail.lastName;
            dob = EmployeeDetail.birthDate;
            id = EmployeeDetail.personId;

        }

        public EmployeeResponse GetEmployeeDetailDataFromNavParameters(NavigationParameters navParams)
        {
            if (navParams.ContainsKey(Constants.NavigationPaths.NAV_KEY_EMPLOYEE))
            {
                return navParams[Constants.NavigationPaths.NAV_KEY_EMPLOYEE] as EmployeeResponse;
            }

            return null;
        }
    }
}
