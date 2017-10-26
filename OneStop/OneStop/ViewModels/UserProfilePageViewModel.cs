using OneStop.IServices;
using OneStop.Models;
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

        private UserData _user;

        public UserData user
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }


        public UserProfilePageViewModel(IAuthService authservice, IPageDialogService dialogService, INavigationService navigationService)
        {
            _authservice = authservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (user == null)
                user = await _authservice.GetProfile();
        }
    }
}
