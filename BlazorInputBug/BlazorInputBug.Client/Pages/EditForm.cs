using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
namespace BlazorInputBug.Client.Pages;


public class ThisCanBeAnyClass
{
    public bool IsLoading { get; set; }
}

public class SomeOtherClass {
    public bool IsLoading { get; set; }
}

public class EditForm : Microsoft.AspNetCore.Components.Forms.EditForm
{

    public SomeOtherClass SomeOtherClass { get; set; } = new();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        Debug.Assert(EditContext != null);
        builder.OpenRegion(EditContext.GetHashCode());
        builder.OpenComponent<CascadingValue<SomeOtherClass>>(1);
        builder.AddComponentParameter(0, "IsFixed", false);
        builder.AddComponentParameter(1, "Name", "SomeOtherClass");
        builder.AddComponentParameter(2, "Value", SomeOtherClass);
        builder.AddComponentParameter(
            3,
            "ChildContent",
            (RenderFragment)((builder2) => { base.BuildRenderTree(builder2); }
            ));
        builder.CloseComponent();
        builder.CloseRegion();
    }


}