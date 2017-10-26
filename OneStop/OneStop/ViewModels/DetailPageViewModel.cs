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

namespace OneStop.ViewModels
{
	public class DetailPageViewModel : ViewModelBase
	{
        IAuthService _authservice;
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

        private ObservableCollection<Image> _images;

        public ObservableCollection<Image> images
        {
            get { return _images; }
            set { SetProperty(ref _images, value); }
        }


        public DetailPageViewModel(IAuthService authservice, IPageDialogService dialogService,
            INavigationService navigationService)
        {
            _authservice = authservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            var param = parameters["item"];
            if(param != null)
            {
                product_name = ((Product)param).product_name;
                price = ((Product)param).price;
                description = ((Product)param).description;
                images = new ObservableCollection<Image>(((Product)param).images);
            }
        }

    }
}
