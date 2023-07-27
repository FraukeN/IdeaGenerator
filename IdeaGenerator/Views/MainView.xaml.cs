using IdeaGenerator.ViewModels;

namespace IdeaGenerator;

public partial class MainView : ContentPage
{
	private readonly MainViewModel _viewModel;
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}

