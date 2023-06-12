using AppliedActivity2.ViewModel;
namespace AppliedActivity2;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
        var viewModel = new HolidayViewModel();
        BindingContext = viewModel;
    }


}


