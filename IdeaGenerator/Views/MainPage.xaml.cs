using IdeaGenerator.ViewModels;

namespace IdeaGenerator;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}

