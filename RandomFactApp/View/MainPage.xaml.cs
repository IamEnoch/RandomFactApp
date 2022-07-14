using RandomFactApp.ViewModels;

namespace RandomFactApp.View;

public partial class MainPage : ContentPage
{
	public MainPage(RandomFactViewModel randomFactViewModel)
	{
		InitializeComponent();
		BindingContext = randomFactViewModel;
	}
}