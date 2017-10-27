using OneStop.IServices;
using OneStop.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
	public class DetailPageViewModel : ViewModelBase
	{
        IDataService _dataservice;
        IPageDialogService _dialogService;
        INavigationService _navigationService;

        private string _product_name;

        public string product_name
        {
            get { return _product_name; }
            set { SetProperty(ref _product_name, value); }
        }

        private string _description;

        public string description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }


        private decimal _price;

        public decimal price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private int _product_id;

        public int product_id
        {
            get { return _product_id; }
            set { SetProperty(ref _product_id, value); }
        }


        private ObservableCollection<Image> _images;

        public ObservableCollection<Image> images
        {
            get { return _images; }
            set { SetProperty(ref _images, value); }
        }

        public DelegateCommand onAddToCart { get; set; }

        public DetailPageViewModel(IDataService dataservice, IPageDialogService dialogService,
            INavigationService navigationService)
        {
            _dataservice = dataservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
            onAddToCart = new DelegateCommand(async () => await AddToCart());
        }

        private async Task AddToCart()
        {
            var result = await _dataservice.AddToCart(product_id, 1);
            if (result)
            {
                await _dialogService.DisplayAlertAsync("Success", string.Format("{0} successfully added to Cart",product_name), "OK");
                await _navigationService.GoBackAsync();
            }else
                await _dialogService.DisplayAlertAsync("Error", string.Format("There is something wrong with {0}", product_name), "OK");

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            var param = parameters["item"];
            if(param != null)
            {
                product_id = ((Product)param).id;
                product_name = ((Product)param).product_name;
                price = ((Product)param).price;
                description = ((Product)param).description;
                images = new ObservableCollection<Image>(((Product)param).images);
            }
        }


        
        
    }
}
