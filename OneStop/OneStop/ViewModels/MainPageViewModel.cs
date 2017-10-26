using OneStop.IServices;
using OneStop.Models;
using Prism.Commands;
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
        
        public DelegateCommand<object> OnItemTappedCommand { get; set; }

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
            OnItemTappedCommand = new DelegateCommand<object>(ItemTapped);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (categories == null)
                categories = new ObservableCollection<Category>(await _authservice.GetHome());
        }

        private async void ItemTapped(object item)
        {
            var p = new NavigationParameters();
            p.Add("item", item);
            await _navigationService.NavigateAsync("DetailPage", p);
        }

    }
}
