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

        private UserData _data;

        public UserData data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }


        public UserProfilePageViewModel(IAuthService authservice, IPageDialogService dialogService, INavigationService navigationService)
        {
            _authservice = authservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (data == null)
                data = await _authservice.GetProfile();
        }
    }
}
