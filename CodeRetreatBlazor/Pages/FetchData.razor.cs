using CodeRetreatBlazor.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.Pages
{
    public partial class FetchData
    {
        [Inject]
        public DataGetter DataGetter { get; set; }
        private WeatherForecast[] forecasts;

        protected async override Task OnInitializedAsync()
        {
            forecasts = await DataGetter.GetDataAsync();
        }
    }
    public class DataGetter
    {
        public DataGetter(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            this.navigationManager = navigationManager;
        }

        public HttpClient _httpClient { get; set; }
        public NavigationManager navigationManager { get; set; }

        public async Task<WeatherForecast[]> GetDataAsync()
        {
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>($"{navigationManager.BaseUri}api/weatherforecast");
        }
    }
}
