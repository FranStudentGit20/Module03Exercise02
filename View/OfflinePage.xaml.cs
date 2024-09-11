namespace Module02Exercise01.View;
using Module02Exercise01.ViewModel;
using Module02Exercise01.Services;
public partial class OfflinePage : ContentPage
{
    public readonly IConfigurationService _configurationService;
    public OfflinePage(IConfigurationService ConfigurationService)
	{
		InitializeComponent();
        _configurationService = ConfigurationService;

        var message = _configurationService.GetMessage();
        MyLabel.Text = message;

    }
    private void OnClickedAppClose(object sender, EventArgs e)
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}