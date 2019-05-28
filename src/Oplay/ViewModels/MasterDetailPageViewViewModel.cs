using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using Oplay.Services.Interfaces;
using Oplay.Constants;

namespace Oplay.ViewModels
{
    public class MasterDetailPageViewViewModel : ViewModelBase
    {
        public readonly INavigationService _navigationService;
        private readonly IStorageHelper _storageHelper;


        private DelegateCommand<string> _navigateMenuItem;
        public DelegateCommand<string> NavigateMenuItem => _navigateMenuItem ?? (_navigateMenuItem = new DelegateCommand<string>(async (uri) => await NavigateToPage(uri)));

        public MasterDetailPageViewViewModel(INavigationService navigationService, Services.Interfaces.IStorageHelper storageHelper, IPageDialogService pageDialogService) : base(navigationService, storageHelper, pageDialogService)
        {
            _navigationService = navigationService;
            _storageHelper = storageHelper;
        }

        public async Task NavigateToPage(string page)
        {

            var navigateToUri = "/MasterDetailPageView/TransparentNavigationPage/" + page;
            _navigationService.NavigateAsync(navigateToUri, useModalNavigation: false, animated: false);
           
        }
    }
}
