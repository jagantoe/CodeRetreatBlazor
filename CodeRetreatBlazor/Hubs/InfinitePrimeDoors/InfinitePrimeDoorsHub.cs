//using CodeRetreatBlazor.Service.InfinitePrimeDoors;
//using Microsoft.AspNetCore.SignalR;
//using System;
//using System.Threading.Tasks;

//namespace CodeRetreatBlazor.Hubs.InfinitePrimeDoors
//{
//    public class InfinitePrimeDoorsHub: Hub
//    {
//        private readonly IChallengeManager<InfinitePrimeDoorChallenge> challengeManager;
//        private ChallengeWrapper<InfinitePrimeDoorChallenge> challengeWrapper;
//        public InfinitePrimeDoorChallenge Challenge
//        {
//            get
//            {
//                if (challengeWrapper == null)
//                {
//                    challengeWrapper = challengeManager.GetChallengeWrapper(Context.ConnectionId);
//                }
//                return challengeWrapper.Challenge;
//            }
//        }

//        public InfinitePrimeDoorsHub(IChallengeManager<InfinitePrimeDoorChallenge> challengeManager)
//        {
//            this.challengeManager = challengeManager;
//        }

//        public async Task StartChallenge()
//        {
//            //Context.User.GetTeamId()
//            var teamId = 1;
//            await challengeManager.AddConnection(Context.ConnectionId, teamId);
//            await Groups.AddToGroupAsync(Context.ConnectionId, lessonId.ToString());
//            await Clients.Caller.SendAsync("AllMessages", Lesson.Chatmessages.Where(x => x.ParentId == null));
//        }

//        public async Task Message(string message)
//        {
//            var user = Context.User.GetUser();

//            if (!string.IsNullOrWhiteSpace(message))
//            {
//                Lesson.AddChatMessage(message, user.Username, user.ProfilePic, user.Role, user.Id);
//                await Clients.Group(Lesson.Id.ToString()).SendAsync("AllMessages", Lesson.Chatmessages);
//                Save();
//            }
//        }

//        public async Task Reply(string message, int parentId)
//        {
//            var user = Context.User.GetUser();

//            if (!string.IsNullOrWhiteSpace(message))
//            {
//                Lesson.AddReply(message, user.Username, user.ProfilePic, user.Role, user.Id, parentId);
//                await Clients.Group(Lesson.Id.ToString()).SendAsync("AllMessages", Lesson.Chatmessages);
//                Save();
//            }
//        }

//        public async Task GetMessages()
//        {
//            await Clients.Group(Lesson.Id.ToString()).SendAsync("AllMessages", Lesson.Chatmessages.Where(x => x.ParentId == null));
//        }

//        public async Task EndLesson()
//        {
//            Lesson.IsActive = false;
//            Save();
//            await Clients.Group(.ToString()).SendAsync("LessonEnded", lessonId);
//            challengeManager.RemoveChallengeAndGroup(challengeWrapper);
//        }

//        private void Save()
//        {
//            challengeWrapper.Save();
//        }
//    }
//}
