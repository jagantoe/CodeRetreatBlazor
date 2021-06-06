//using CodeRetreatBlazor.DataAccess;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CodeRetreatBlazor.Hubs
//{
//    public class ChallengeWrapper<TModel> : IDisposable
//    {
//        public int TeamId { get; set; }
//        protected readonly DbContext Context;
//        public TModel Challenge;

//        public ChallengeWrapper()
//        {
//            Context = new ChallengeContext();
//            StartChallenge();
//        }

//        public abstract void StartChallenge();

//        protected void Save()
//        {
//            Context.Update(Challenge);
//            Context.SaveChanges();
//        }

//        public void Dispose()
//        {
//            Context.Dispose();
//        }
//    }
//}
