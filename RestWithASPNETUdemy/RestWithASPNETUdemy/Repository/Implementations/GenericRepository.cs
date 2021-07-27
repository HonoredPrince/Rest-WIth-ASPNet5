using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MySQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(obj => obj.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
            {
                return null;
            }

            var result = _dataset.SingleOrDefault(obj => obj.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return item;
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }
    }
}
