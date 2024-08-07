namespace TylerDM.StandardLibrary.Blazor.Interface;

[DependencyInjectable(ServiceLifetime.Scoped)]
public class Clipboard(IJSRuntime _js)
{
	public ValueTask Copy(string text) =>
		_js.InvokeVoidAsync("navigator.clipboard.writeText", text);
}
