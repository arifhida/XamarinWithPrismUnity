using OneStop.IServices;
using OneStop.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }


        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private string _Confirmation;

        public string Confirmation
        {
            get { return _Confirmation; }
            set { SetProperty(ref _Confirmation, value); }
        }
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;
        IAuthService _authService;
        public DelegateCommand OnRegisterCommand { get; set; }

        public RegisterPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService,
            IAuthService authService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _authService = authService;
            OnRegisterCommand = new DelegateCommand(async () => await Register());
        }

        async Task Register()
        {
            var register = new RegisterModel()
            {
                email = this._Email,
                name = this._Name,
                password = this._Password,
                password_confirmation = this._Confirmation
            };
            var result = await _authService.RegisterAsync(register);
            if (result.Succes)
            {
                await _navigationService.NavigateAsync("/Initial/Navigate/LoginPage", null, false);
                await _pageDialogService.DisplayAlertAsync("Success", result.Message, "OK");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Error", result.Message, "OK");
            }
        }
    }
}
