using Company.BlazorApp.Repositories;
using Company.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Company.BlazorApp.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject]
        private IRepositrory Repositrory { get; set; } = null!;

        private List<Country>? Countries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repositrory.GetAsync<List<Country>>("api/countries");
            Countries = responseHttp.Response!;
        }

    }
}