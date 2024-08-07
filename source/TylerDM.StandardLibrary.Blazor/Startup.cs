namespace TylerDM.StandardLibrary.Blazor;

public static class Startup
{
	public static void AddTylerDmStdLibBlazor(this IServiceCollection services)
	{
		services.AddOrangePeeledServices();
	}
}
