using Company.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Company.BlazorApp.Shared;

public partial class BaseList<Titem>
{
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Parameter] public RenderFragment? Loading { get; set; }
    [Parameter] public RenderFragment? NoRecords { get; set; }
    [EditorRequired, Parameter] public RenderFragment Body { get; set; } = null!;
    [EditorRequired, Parameter] public List<Titem> MyList { get; set; } = null!;
}