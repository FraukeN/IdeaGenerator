using IdeaGenerator.Repositories;
using IdeaGenerator.Utils;

namespace IdeaGenerator;

public partial class App : Application
{
	public static AgentRepository AgentRepo { get; private set; }
	public App(AgentRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		AgentRepo = repo;
	}

	protected override async void OnStart()
	{
		await DatabaseInitialiser.InitialiseDatabase();
	}
}
