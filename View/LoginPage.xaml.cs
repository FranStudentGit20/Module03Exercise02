using Module02Exercise01.ViewModel;
using Module02Exercise01.Services;
using Microsoft.Maui.Controls;

namespace Module02Exercise01.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly IMyService _myService;

        public LoginPage(IMyService myService)
        {
            InitializeComponent();
            _myService = myService;

            var message = _myService.GetMessage();
            MyLabel.Text = message;
        }

        private async void OnLogin(object sender, EventArgs e)
        {
            string username = userEntry.Text;
            string password = passEntry.Text;

            
            if (username == "admin" && password == "password")
            {
                
                await Navigation.PushAsync(new EmployeePage());
            }
            else
            {
                await DisplayAlert("Login Failed", "Incorrect username or password.", "OK");
            }
        }
    }
}