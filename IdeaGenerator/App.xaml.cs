using IdeaGenerator.Repositories;
using IdeaGenerator.Utils;

namespace IdeaGenerator;

public partial class App : Application
{
	public static AgentRepository AgentRepo { get; private set; }
    public static EngineRepository EngineRepo { get; private set; }
    public App(AgentRepository agentRepo, EngineRepository engineRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		AgentRepo = agentRepo;
		EngineRepo = engineRepo;
	}

	protected override async void OnStart()
	{
		await DatabaseInitialiser.InitialiseDatabase();
	}
}
