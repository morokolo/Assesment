using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oplay.Constants;
using Oplay.Services.Interfaces;
using Prism;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace Oplay.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {

        protected INavigationService NavigationService { get; private set; }
        protected IStorageHelper StorageHelper { get; private set; }
        protected IPageDialogService DialogService { get; private set; }

        private int _navClicks;
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public ViewModelBase(INavigationService navigationService, IStorageHelper storageHelper, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            StorageHelper = storageHelper;
            DialogService = pageDialogService;

            this._navClicks = 0;
            EndLoader();
        }

        public bool IsBusy { get; set; }

        public string LoaderText { get; set; }

        public string Animation
        {
            get
            {
                return "Loader.json";
            }
        }

        public void StartLoader(string loaderText)
        {
            SetLoaderText(loaderText);
            IsBusy = true;
        }

        public void EndLoader()
        {
            LoaderText = "";
            IsBusy = false;
        }

        public void SetLoaderText(string loaderText)
        {
            LoaderText = loaderText;
        }

       

        public async Task PushPage(string registeredPageName, NavigationParameters parameters = null)
        {

            this._navClicks += 1;
            if (this._navClicks < 2)
                await this.NavigationService.NavigateAsync(registeredPageName, parameters);
            this._navClicks = 0;
        }

        public async Task PopPage(NavigationParameters parameters = null)
        {
            this._navClicks += 1;
            if (this._navClicks < 2)
                await this.NavigationService.GoBackAsync(parameters);
            this._navClicks = 0;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

    }
}
    //public class ViewModelBase : BindableBase, IApplicationLifecycleAware, IActiveAware, INavigationAware, IDestructible, IConfirmNavigation, IConfirmNavigationAsync, IPageLifecycleAware
    //{
    //protected IPageDialogService _pageDialogService { get; }

    //protected IDeviceService _deviceService { get; }

    //protected INavigationService _navigationService { get; }

    //protected IStorageHelper StorageHelper { get; private set; }

    //public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService,
    //                     IDeviceService deviceService, IStorageHelper storageHelper)
    //{
    //    _pageDialogService = pageDialogService;
    //    _deviceService = deviceService;
    //    StorageHelper = storageHelper;
    //    _navigationService = navigationService;
    //    EndLoader();
    //}


    //public virtual bool ValidateInputs(object inputs)
    //{
    //    if (inputs != null)
    //    {
    //        var objStr = JsonConvert.SerializeObject(inputs);
    //        var objDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(objStr);

    //        foreach (KeyValuePair<string, string> entry in objDic)
    //        {
    //            if (String.IsNullOrWhiteSpace(entry.Value))
    //                return false;
    //        }

    //        return true;
    //    }

    //    return false;
    //}

    //public bool IsLoaderBusy { get; set; }

    //public string LoaderText { get; set; }

    //public string Animation
    //{
    //    get
    //    {
    //        return "Loader.json";
    //    }
    //}

    //public void StartLoader(string loaderText)
    //{
    //    SetLoaderText(loaderText);
    //    IsLoaderBusy = true;
    //}

    //public void EndLoader()
    //{
    //    LoaderText = "";
    //    IsLoaderBusy = false;
    //}

    //public void SetLoaderText(string loaderText)
    //{
    //    LoaderText = loaderText;
    //}

    //private string _title;
    //public string Title
    //{
    //    get => _title;
    //    set => SetProperty(ref _title, value);
    //}

    //private string _subtitle;
    //public string Subtitle
    //{
    //    get => _subtitle;
    //    set => SetProperty(ref _subtitle, value);
    //}

    //private string _icon;
    //public string Icon
    //{
    //    get => _icon;
    //    set => SetProperty(ref _icon, value);
    //}

    //private bool _isBusy;
    //public bool IsBusy
    //{
    //    get => _isBusy;
    //    set => SetProperty(ref _isBusy, value, onChanged: OnIsBusyChanged);
    //}

    //private bool _isNotBusy;
    //public bool IsNotBusy
    //{
    //    get => _isNotBusy;
    //    set => SetProperty(ref _isNotBusy, value, onChanged: OnIsNotBusyChanged);
    //}

    //private bool _canLoadMore;
    //public bool CanLoadMore
    //{
    //    get => _canLoadMore;
    //    set => SetProperty(ref _canLoadMore, value);
    //}

    //private string _header;
    //public string Header
    //{
    //    get => _header;
    //    set => SetProperty(ref _header, value);
    //}

    //private string _footer;
    //public string Footer
    //{
    //    get => _footer;
    //    set => SetProperty(ref _footer, value);
    //}

    //private void OnIsBusyChanged() => IsNotBusy = !IsBusy;

    //private void OnIsNotBusyChanged() => IsBusy = !IsNotBusy;

    //#region IActiveAware

    //private bool _isActive;
    //public bool IsActive
    //{
    //    get => _isActive;
    //    set => SetProperty(ref _isActive, value, onChanged: OnIsActiveChanged);
    //}

    //public event EventHandler IsActiveChanged;

    //private void OnIsActiveChanged()
    //{
    //    IsActiveChanged?.Invoke(this, EventArgs.Empty);

    //    if (IsActive)
    //    {
    //        OnIsActive();
    //    }
    //    else
    //    {
    //        OnIsNotActive();
    //    }
    //}

    //protected virtual void OnIsActive() { }

    //protected virtual void OnIsNotActive() { }

    //#endregion IActiveAware

    //#region INavigationAware

    //public virtual void OnNavigatingTo(INavigationParameters parameters) { }

    //public virtual void OnNavigatedTo(INavigationParameters parameters) { }

    //public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

    //#endregion INavigationAware

    //#region IDestructible

    //public virtual void Destroy() { }

    //#endregion IDestructible

    //#region IConfirmNavigation

    //public virtual bool CanNavigate(INavigationParameters parameters) => true;

    //public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) =>
    //    Task.FromResult(CanNavigate(parameters));

    //#endregion IConfirmNavigation

    //#region IApplicationLifecycleAware

    //public virtual void OnResume() { }

    //public virtual void OnSleep() { }

    //#endregion IApplicationLifecycleAware

    //#region IPageLifecycleAware

    //public virtual void OnAppearing() { }

    //public virtual void OnDisappearing() { }

    //#endregion IPageLifecycleAware
