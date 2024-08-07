namespace TylerDM.StandardLibrary.Blazor.Components.Web;

public static class KeyboardEventArgsExt
{
	public static bool IsEnter(this KeyboardEventArgs args) =>
		args.Code is "Enter" or "NumpadEnter";
}
