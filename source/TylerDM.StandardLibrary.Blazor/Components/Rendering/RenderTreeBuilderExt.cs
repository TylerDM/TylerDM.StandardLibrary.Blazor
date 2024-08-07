namespace TylerDM.StandardLibrary.Blazor.Components.Rendering;

public static class RenderTreeBuilderExt
{
	public static void BuildComponent<T>(this RenderTreeBuilder builder, Action<RenderTreeBuilder> configure, int sequence)
		where T : ComponentBase
	{
		builder.OpenComponent<T>(sequence);
		configure(builder);
		builder.CloseComponent();
	}

	public static void BuildComponent(this RenderTreeBuilder builder, Type componentType, Action<RenderTreeBuilder> configure, int sequence)
	{
		builder.OpenComponent(sequence, componentType);
		configure(builder);
		builder.CloseComponent();
	}
}
