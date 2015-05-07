namespace TheIocProject.Services
{
	public interface IServerStatusService
	{
		string GetWorkingServers();
		string GetBrokenServers();
		bool AllServersAreWorking();
	}
}