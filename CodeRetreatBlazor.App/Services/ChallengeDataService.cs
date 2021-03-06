using CodeRetreatBlazor.Domain;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.App.Services
{
    public class ChallengeDataService
    {
        private readonly HttpClient httpClient;
        private readonly NavigationManager navigationManager;

        public ChallengeDataService(HttpClient httpClient, NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
        }

        public async Task<Challenge> GetChallengeInfoById(int id)
        {
            return await httpClient.GetFromJsonAsync<Challenge>($"{navigationManager.BaseUri}api/challenge/{id}");
        }

        public async Task<List<Challenge>> GetAllChallengeRatings()
        {
            return await httpClient.GetFromJsonAsync<List<Challenge>>($"{navigationManager.BaseUri}api/challenge/ratings");
        }
    }
}
