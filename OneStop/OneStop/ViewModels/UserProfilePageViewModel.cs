using OneStop.Helpers;
using OneStop.IServices;
using OneStop.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
    public class UserProfilePageViewModel : ViewModelBase
    {
        IAuthService _authservice;
        IPageDialogService _dialogService;
        INavigationService _navigationService;

        private UserData _data;

        public UserData data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public DelegateCommand onLogout { get; set; }

        public UserProfilePageViewModel(IAuthService authservice, IPageDialogService dialogService, INavigationService navigationService)
        {
            _authservice = authservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
            onLogout = new DelegateCommand(async () => await Logout());
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (data == null)
                data = await _authservice.GetProfile();
        }

        public async Task Logout()
        {
            Settings.access_token = "";
            await _navigationService.NavigateAsync("/Initial/Navigate/MainPage", null, false);
        }
    }
}
