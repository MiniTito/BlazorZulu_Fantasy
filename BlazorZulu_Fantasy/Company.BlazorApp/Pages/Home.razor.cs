using Company.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Company.BlazorApp.Pages;

public partial class Home
{
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
}