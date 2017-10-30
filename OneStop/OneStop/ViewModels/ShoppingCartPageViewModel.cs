using OneStop.IServices;
using OneStop.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
    public class ShoppingCartPageViewModel : ViewModelBase
    {
        IDataService _dataservice;
        IPageDialogService _dialogService;
        INavigationService _navigationService;


        private Cart _cart;

        public Cart cart
        {
            get { return _cart; }
            set { SetProperty(ref _cart, value); }
        }

        public DelegateCommand<Object> DeleteItemCommand { get; set; }


        public ShoppingCartPageViewModel(IDataService dataservice, IPageDialogService dialogService, INavigationService navigationService)
        {
            _dataservice = dataservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
            DeleteItemCommand = new DelegateCommand<object>(delete);
        }

        private async void delete(object obj)
        {
            var item = (CartDetail)obj;
            cart = await _dataservice.RemoveFromCart(item.product.id);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (cart == null)
                cart = await _dataservice.GetCart();
        }

    }
}
