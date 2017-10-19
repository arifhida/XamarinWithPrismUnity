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

        public List<MasterItem> listMenu
        {
            get { return _listMenu; }
            set { _listMenu = value; }
        }

        public MasterPageViewModel()
        {
             
        }
    }
}
