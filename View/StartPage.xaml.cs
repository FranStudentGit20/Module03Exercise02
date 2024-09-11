using Module02Exercise01.Services;

namespace Module02Exercise01.View;

public partial class StartPage : ContentPage
{
	private readonly IMyService _myService;
	public StartPage(IMyService myService)
	{
		InitializeComponent();
		_myService = myService;

		var message = _myService.GetMessage();
		MyLabel.Text = message;
	}
}