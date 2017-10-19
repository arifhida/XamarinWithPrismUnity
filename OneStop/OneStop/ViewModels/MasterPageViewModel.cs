using OneStop.Helpers;
using OneStop.IServices;
using OneStop.Models;
using OneStop.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneStop.ViewModels
{
    public class MasterPageViewModel : BindableBase
    {

        private List<MasterItem> _listMenu;
        IAuthService _authservice;

        public List<MasterItem> listMenu
        {
            get { return _listMenu; }
            set { _listMenu = value; }
        }

        public MasterPageViewModel(IAuthService authservice)
        {
            _authservice = authservice;
            var isLogin = !string.IsNullOrEmpty(Settings.access_token);
            _listMenu = _authservice.GetMenus(isLogin);
        }
    }
}
