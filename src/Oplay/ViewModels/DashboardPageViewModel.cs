using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Oplay.Constants;
using Oplay.Models.Response;
using Oplay.Services.Interfaces;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Oplay.ViewModels
{
    public class DashboardPageViewModel : ViewModelBase, INavigatedAware
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeResponse GetEmployeeResponse { get; set; }
        public List<EmployeeResponse> AllEmployees {get; set;}
        public string FullName { get; set; }

       
        public ICommand GoToEmployeeDetailCommand
        {
            get
            {
                return new Command<EmployeeResponse>(async (employee) =>
                {
                    var navParams = new NavigationParameters
                    {
                        { Constants.NavigationPaths.NAV_KEY_EMPLOYEE, employee }
                    };

                  await PushPage(Constants.NavigationPaths.MY_PROFILE_PAGE, navParams);

                });
            }
        }

        public DashboardPageViewModel(INavigationService navigationService, IStorageHelper storageHelper, IPageDialogService pageDialogService,  IEmployeeService employeeService) : base(navigationService, storageHelper, pageDialogService)
        {
            _employeeService = employeeService;
        }


        public override async void OnNavigatedTo(NavigationParameters parameters)
        { 

            StartLoader("getting available matches...");

            AllEmployees = await RequestListOfEmployeesResponse();
            
            if (AllEmployees == null)
            {
                //handle
            }



        }

        public async Task<List<EmployeeResponse>> RequestListOfEmployeesResponse()
        {

            var employees = await _employeeService.GetEmployeesAsync();

            if (employees == null)
            {
                return new List<EmployeeResponse>();
            }

            return employees;
        }

    }
}
