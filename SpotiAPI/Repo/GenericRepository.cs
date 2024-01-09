
using Microsoft.Extensions.Logging;
using SpotiAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SpotifyDBContext _context;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(SpotifyDBContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create(T entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting Item");
                var t = _context.Set<T>().Find(id);
                if (t == null)
                {
                    throw new Exception("Item not find");
                }
                _context.Set<T>().Remove(t);
                _context.SaveChanges();
                _logger.LogInformation("Item Deleted");
                return "Item deleted";

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error:{ex.Message}");
                throw;
            }
        }
        public List<T> GetAll()
        {
            try
            {
                var list = _context.Set<T>().ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetSingle(int id)
        {
            try
            {
                var t = _context.Set<T>().Find(id);
                return t;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(int id, T entity)
        {
            try
            {
                var tToUp = _context.Set<T>().Find(id);
                _context.Entry(tToUp).CurrentValues.SetValues(entity);
                _context.SaveChanges(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
