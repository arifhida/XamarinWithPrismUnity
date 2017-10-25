using OneStop.Helpers;
using OneStop.IServices;
using OneStop.Models;
using OneStop.Views;
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
    public class MasterPageViewModel : ViewModelBase
    {

        private List<MasterItem> _listMenu;
        IAuthService _authservice;
        IPageDialogService _dialogService;
        INavigationService _navigationService;

        public DelegateCommand<string> OnItemTappedCommand { get; set; }

        public List<MasterItem> listMenu
        {
            get { return _listMenu; }
            set { _listMenu = value; }
        }

        public MasterPageViewModel(IAuthService authservice, IPageDialogService dialogService,
            INavigationService navigationService)
        {
            _authservice = authservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
            var isLogin = !string.IsNullOrEmpty(Settings.access_token);
            _listMenu = _authservice.GetMenus(isLogin);
            OnItemTappedCommand = new DelegateCommand<string>(Tapped);
        }

        private void Tapped(string navigation)
        {
            _navigationService.NavigateAsync(navigation);
        }
    }
}
