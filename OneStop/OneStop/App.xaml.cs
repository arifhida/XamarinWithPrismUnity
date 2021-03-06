﻿using Prism.Unity;
using OneStop.Views;
using Xamarin.Forms;
using OneStop.Services;
using OneStop.IServices;
using Microsoft.Practices.Unity;

namespace OneStop
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("Initial/Navigate/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IAuthService, AuthService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Initial>();
            Container.RegisterTypeForNavigation<Navigate>();
            Container.RegisterTypeForNavigation<MasterPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<DetailPage>();
            Container.RegisterTypeForNavigation<CategoryPage>();
            Container.RegisterTypeForNavigation<UserProfilePage>();
            Container.RegisterTypeForNavigation<ShoppingCartPage>();
            Container.RegisterTypeForNavigation<PaymentPage>();
        }
    }
}
