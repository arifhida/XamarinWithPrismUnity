using OneStop.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneStop.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(2000);

            // Start animation
            //await Task.WhenAll(
            //    SplashGrid.FadeTo(0, 2000),
            //    Logo.ScaleTo(10, 2000)
            //    );
        }
        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((MainPageViewModel)this.BindingContext).OnItemTappedCommand.Execute(args.Item);
        }
    }
}
