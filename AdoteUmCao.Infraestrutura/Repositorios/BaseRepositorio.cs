using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Duloren.Infraestrutura;

namespace AdoteUmCao.Infraestrutura.Repositorios
{
    public class BaseRepositorio<T> where T : class
    {
        public virtual List<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            using (Contexto db = new Contexto())
            {
                List<T> list;
                IQueryable<T> dbQuery = db.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
                return list;
            }
        }

        public virtual List<T> GetAll(params string[] navigationProperties)
        {
            using (Contexto db = new Contexto())
            {
                List<T> list;
                IQueryable<T> dbQuery = db.Set<T>();

                //Apply eager loading
                foreach (string navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
                return list;
            }
        }

        public virtual List<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (Contexto db = new Contexto())
            {
                List<T> list;
                IQueryable<T> dbQuery = db.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();

                return list;
            }
        }

        public virtual List<T> GetList(Func<T, bool> where, params string[] navigationProperties)
        {
            using (Contexto db = new Contexto())
            {
                List<T> list;
                IQueryable<T> dbQuery = db.Set<T>();

                //Apply eager loading
                foreach (string navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();

                return list;
            }
        }

        public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (Contexto db = new Contexto())
            {
                T item = null;
                IQueryable<T> dbQuery = db.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
                return item;
            }
        }

        public virtual T GetSingle(Func<T, bool> where, params string[] navigationProperties)
        {
            using (Contexto db = new Contexto())
            {
                T item = null;
                IQueryable<T> dbQuery = db.Set<T>();

                //Apply eager loading
                foreach (string navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
                return item;
            }
        }

        public virtual void Add(params T[] items)
        {
            using (Contexto db = new Contexto())
            {
                foreach (T item in items)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.SaveChanges();
            }
        }

        public virtual void Update(params T[] items)
        {
            using (Contexto db = new Contexto())
            {
                foreach (T item in items)
                {
                    db.Entry(item).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

        public virtual void Remove(params T[] items)
        {
            using (Contexto db = new Contexto())
            {
                foreach (T item in items)
                {
                    db.Entry(item).State = EntityState.Deleted;
                }

                db.SaveChanges();
            }
        }
    }
}