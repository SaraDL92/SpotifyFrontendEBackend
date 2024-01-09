using System.Collections.Generic;

namespace SpotiAPI.Repo
{
    public interface IGenericRepository<T> where T : class
    {
        public void Create(T entity);
        public void Update(int id, T entity);
        public string Delete(int id);
        public T GetSingle(int id);
        public List<T> GetAll();
    }
}
