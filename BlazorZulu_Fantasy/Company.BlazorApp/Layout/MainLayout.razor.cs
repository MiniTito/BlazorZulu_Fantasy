using Company.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Company.BlazorApp.Layout;

public partial class MainLayout
{
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
}