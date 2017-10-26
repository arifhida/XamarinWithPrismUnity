using OneStop.IServices;
using OneStop.Models;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;

namespace OneStop.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        IAuthService _authservice;
        IPageDialogService _dialogService;
        INavigationService _navigationService;

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }


        public MainPageViewModel(IAuthService authservice, IPageDialogService dialogService,
            INavigationService navigationService)
        {
            _authservice = authservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (categories == null)
                categories = new ObservableCollection<Category>(await _authservice.GetHome());
        }


    }
}
