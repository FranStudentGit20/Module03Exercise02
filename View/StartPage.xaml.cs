using Module02Exercise01.Services;

namespace Module02Exercise01.View;

public partial class StartPage : ContentPage
{
	private readonly IConfigurationService _configurationService;
	public StartPage(IConfigurationService ConfigurationService)
	{
		InitializeComponent();
        _configurationService = ConfigurationService;

		var message = _configurationService.GetMessage();
		MyLabel.Text = message;
	}
}