using CarBook.Dto.CarDtos;
using CarBook.Dto.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultTop5CarsWithBrandComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTop5CarsWithBrandComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7295/api/Cars/GetTop5CarWithBrandQueryHandler");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTop5CarsWithBrandsDtos>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
