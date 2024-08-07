namespace TylerDM.StandardLibrary.Blazor.Components;

public static class NavigationManagerExt
{
	#region methods
	public static string GetParameter(this NavigationManager navigationManager, string key)
	{
		if (string.IsNullOrEmpty(key)) return string.Empty;

		var query = HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
		var values = query.GetValues(key) ?? [];
		if (values.Length is 0) return string.Empty;
		return values[0];
	}

	public static int GetIntParameter(this NavigationManager navigationManager, string key)
	{
		var value = navigationManager.GetParameter(key);
		if (string.IsNullOrWhiteSpace(value)) return default;

		return int.Parse(value);
	}

	public static Guid GetGuidParameter(this NavigationManager navigationManager, string key)
	{
		var value = navigationManager.GetParameter(key);
		if (string.IsNullOrWhiteSpace(value)) return default;

		return Guid.Parse(value);
	}

	public static void SetParameter(this NavigationManager nav, string key, string value)
	{
		var uri = nav.ToAbsoluteUri(nav.Uri);
		var parameters = HttpUtility.ParseQueryString(new Uri(nav.Uri).Query);

		parameters.Remove(key);
		if (string.IsNullOrWhiteSpace(value) is false)
			parameters.Add(key, value);

		var url = uri.AbsolutePath;
		url += '?';
		foreach (var parameterKey in parameters.AllKeys)
		{
			var parameterValue = parameters[parameterKey];
			url += $"{parameterKey}={parameterValue}&";
		}

		url = url[..^1];

		nav.NavigateTo(url);
	}

	//public static void NavigateTo(this NavigationManager navigationManager, string endpoint, params IWebParameter[] parameters) =>
	//	navigationManager.NavigateTo(UrlFactory.Create(endpoint, parameters));
	#endregion
}
