using Module02Exercise01.View;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using System.Threading.Tasks;

namespace Module02Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://www.google.com/";

        private readonly IServiceProvider _serviceProvider;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            MainPage = new ContentPage
            {
                Content = new Label { Text = "Loading..." }
            };
        }

        protected override async void OnStart()
        {

            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                MainPage = _serviceProvider.GetRequiredService<LoginPage>();

                Debug.WriteLine("Application Started");
                
            }
            else
            {
                MainPage = _serviceProvider.GetRequiredService<OfflinePage>();
            }
        }

        protected override void OnSleep()
        {
            
            Console.WriteLine("The app is in sleep mode.");
        }

        protected override void OnResume()
        {
            
            Console.WriteLine("The app is resumed.");
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
