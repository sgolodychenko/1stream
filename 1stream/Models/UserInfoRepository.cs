using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OneStream.Models
{ 
    public class UserInfoRepository : IUserInfoRepository
    {
        OneStreamContext context = new OneStreamContext();

        public IQueryable<UserInfo> All
        {
            get { return context.UserInfoes; }
        }

        public IQueryable<UserInfo> AllIncluding(params Expression<Func<UserInfo, object>>[] includeProperties)
        {
            IQueryable<UserInfo> query = context.UserInfoes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public UserInfo Find(int id)
        {
            return context.UserInfoes.Find(id);
        }

        public void InsertOrUpdate(UserInfo userinfo)
        {
            if (userinfo.UserId == default(int)) {
                // New entity
                context.UserInfoes.Add(userinfo);
            } else {
                // Existing entity
                context.Entry(userinfo).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var userinfo = context.UserInfoes.Find(id);
            context.UserInfoes.Remove(userinfo);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IUserInfoRepository : IDisposable
    {
        IQueryable<UserInfo> All { get; }
        IQueryable<UserInfo> AllIncluding(params Expression<Func<UserInfo, object>>[] includeProperties);
        UserInfo Find(int id);
        void InsertOrUpdate(UserInfo userinfo);
        void Delete(int id);
        void Save();
    }
}