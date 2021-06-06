//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CodeRetreatBlazor.Hubs
//{
//    public abstract class ChallengeManager<TModel>: IChallengeManager<TModel>
//    {
//        private List<ChallengeConnection> Connections = new List<ChallengeConnection>();
//        private List<ChallengeWrapper<TModel>> ChallengeWrappers = new List<ChallengeWrapper<TModel>>();

//        public Task AddConnection(string connectionId, int teamId)
//        {
//            Connections.Add(new ChallengeConnection { ConnectionId = connectionId, TeamId = teamId });
//            var lessonWrapper = ChallengeWrappers.SingleOrDefault(x => x.TeamId== teamId);

//            if (lessonWrapper == null)
//            {
//                lessonWrapper = new ChallengeWrapper<TModel>();
//                await lessonWrapper.StartChallenge();
//                lessonWrapper.Lesson.IsActive = true;
//                lessonWrapper.Lesson.TrimDuplicateChatMessages();
//                lessonWrapper.Save();

//                LessonWrappers.Add(lessonWrapper);
//            }
//        }

//        public ChallengeWrapper<TModel> GetChallengeWrapper(string connectionId)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveChallengeAndGroup(ChallengeWrapper<TModel> challengeWrapper)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
