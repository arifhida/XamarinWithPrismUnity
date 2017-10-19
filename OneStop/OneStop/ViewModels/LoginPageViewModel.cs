using OneStop.IServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
    public class LoginPageViewModel : BindableBase, IDestructible
    {
        public DelegateCommand OnLoginCommand { get; set; }
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;
        IAuthService _authService;
        public LoginPageViewModel(INavigationService navigationService, 
            IPageDialogService pageDialogService, IAuthService authService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _authService = authService;
            OnLoginCommand = new DelegateCommand(async () => await Login());
        }

        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        async Task Login()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                await _pageDialogService.DisplayAlertAsync("Error", "Username and Password is required", "OK");
            else
            {
                var isLoggedin = await _authService.LoginAsync(Username, Password);
                if (isLoggedin)
                {
                    var param = new NavigationParameters();
                    param.Add("isLoggedIn", true);
                    await _navigationService.NavigateAsync("/Initial/Navigate/MainPage", param, false);
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "The user credentials were incorrect.", "OK");
                }
               
            }
        }

        public void Destroy()
        {
            
        }
    }
}
