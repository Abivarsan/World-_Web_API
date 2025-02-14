using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using World_Web_Application.DTO.Country;


namespace World_Web_Application.Pages
{
    public class CountryModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]

        public List<GetAllCountryDto> Countries { get; set; } = new List<GetAllCountryDto>();

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("WorldWebAPI");
            Countries = await httpClient.GetFromJsonAsync<List<GetAllCountryDto>>("api/Country");
        }
    }
}
