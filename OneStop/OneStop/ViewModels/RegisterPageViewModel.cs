using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }


        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private string _Confirmation;

        public string Confirmation
        {
            get { return _Confirmation; }
            set { SetProperty(ref _Confirmation, value); }
        }



    }
}
