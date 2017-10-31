using OneStop.IServices;
using OneStop.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
    public class PaymentPageViewModel : ViewModelBase
    {
        IDataService _dataservice;
        IPageDialogService _dialogService;
        INavigationService _navigationService;

        private ObservableCollection<PaymentMethod> _payments;

        public ObservableCollection<PaymentMethod> payments
        {
            get { return _payments; }
            set { SetProperty(ref _payments, value); }
        }

        private int _cartId;

        public DelegateCommand<string> onPayClick { get; set; }

        public int cartId
        {
            get { return _cartId; }
            set { SetProperty(ref _cartId, value); }
        }

        private decimal _TotalPrice;

        public decimal TotalPrice
        {
            get { return _TotalPrice; }
            set { SetProperty(ref _TotalPrice, value); }
        }


        public PaymentPageViewModel(IDataService dataservice, IPageDialogService dialogService, INavigationService navigationService)
        {
            _dataservice = dataservice;
            _dialogService = dialogService;
            _navigationService = navigationService;
            onPayClick = new DelegateCommand<string>(PaymentClick);
        }

        private async void PaymentClick(string paymentcode)
        {
            var payment = payments.Where(x => x.code == paymentcode).FirstOrDefault();
            await _dialogService.DisplayAlertAsync("Payment", string.Format("Payment using {0} selected", payment.name), "OK");
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (payments == null)
                payments = new ObservableCollection<PaymentMethod>(await _dataservice.GetPayment());
            var param = parameters["cartId"];
            if(param != null)
            {
                cartId = (int)param;
                TotalPrice = (decimal)parameters["TotalPrice"];
            }
        }
    }
}
