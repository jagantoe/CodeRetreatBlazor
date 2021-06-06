using CodeRetreatBlazor.App.Services;
using CodeRetreatBlazor.Domain;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.App.Pages
{
    public partial class ChallengeOverview
    {
        [Parameter]
        public string ChallengeId { get; set; }
        [Inject]
        public ChallengeDataService ChallengeDataService { get; set; }
        public Challenge Challenge { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Challenge = await ChallengeDataService.GetChallengeInfoById(int.Parse(ChallengeId));
        }
    }
}
