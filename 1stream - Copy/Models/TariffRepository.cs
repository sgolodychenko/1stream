using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace _1stream.Models
{ 
    public class TariffRepository : ITariffRepository
    {
        OneStreamContext context = new OneStreamContext();

        public IQueryable<Tariff> All
        {
            get { return context.Tariffs; }
        }

        public IQueryable<Tariff> AllIncluding(params Expression<Func<Tariff, object>>[] includeProperties)
        {
            IQueryable<Tariff> query = context.Tariffs;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Tariff Find(int id)
        {
            return context.Tariffs.Find(id);
        }

        public void InsertOrUpdate(Tariff tariff)
        {
            if (tariff.TariffId == default(int)) {
                // New entity
                context.Tariffs.Add(tariff);
            } else {
                // Existing entity
                context.Entry(tariff).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var tariff = context.Tariffs.Find(id);
            context.Tariffs.Remove(tariff);
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

    public interface ITariffRepository : IDisposable
    {
        IQueryable<Tariff> All { get; }
        IQueryable<Tariff> AllIncluding(params Expression<Func<Tariff, object>>[] includeProperties);
        Tariff Find(int id);
        void InsertOrUpdate(Tariff tariff);
        void Delete(int id);
        void Save();
    }
}