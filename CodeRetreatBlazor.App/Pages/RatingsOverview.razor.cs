using CodeRetreatBlazor.App.Services;
using CodeRetreatBlazor.Domain;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.App.Pages
{
    public partial class RatingsOverview
    {
        [Inject]
        public ChallengeDataService ChallengeDataService { get; set; }
        public List<Challenge> Challenges { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetChallenges();
        }
        
        public async Task GetChallenges()
        {
            Challenges = await ChallengeDataService.GetAllChallengeRatings();
            StateHasChanged();
        }
    }
}
