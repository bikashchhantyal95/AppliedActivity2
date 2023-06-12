using AppliedActivity2.ViewModel;
namespace AppliedActivity2;

public partial class MainPage : ContentPage
{
	

	public MainPage(HolidayViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


}


