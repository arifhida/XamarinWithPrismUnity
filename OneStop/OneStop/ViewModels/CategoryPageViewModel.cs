using OneStop.IServices;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
    public class CategoryPageViewModel :ViewModelBase
    {
        IAuthService _authservice;
        IPageDialogService _dialogService;
        INavigationService _navigationService;

        public CategoryPageViewModel(IAuthService authservice, IPageDialogService dialogService, INavigationService navigationService)
        {
            _authservice = authservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }
    }
}
