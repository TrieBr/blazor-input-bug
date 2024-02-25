using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
namespace InputBug.Shared;


public class InputTextExtend : Microsoft.AspNetCore.Components.Forms.InputText
{
    [CascadingParameter(Name = "ThisCanBeAnyClass")]
    public ThisCanBeAnyClass? ThisCanBeAnyClass { get; set; }


     protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "input");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        if (!string.IsNullOrEmpty(NameAttributeValue))
            builder.AddAttribute(2, "name", NameAttributeValue);
        builder.AddAttribute(3, "class", "form-control");
        builder.AddAttribute(4, "value", CurrentValueAsString);
        builder.AddAttribute(5, "oninput", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.SetUpdatesAttributeName("value");
        builder.AddElementReferenceCapture(6, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }


}