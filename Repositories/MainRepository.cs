

using System.Collections.Generic;
using angularNet.Models;
using System.Linq;
using angularNet.Services;
using Microsoft.EntityFrameworkCore;

namespace angularNet.Repositories {


    public abstract class MainRepository<C, T> : IFinanceCRUD<T>
                        where T : class where C : DbContext, new()
    {
        private C _currentEntity = new C();
        protected C _DbContext {
            get { return _currentEntity; }
            set { _currentEntity = value; }
        }
        public virtual void Delete(T entity) {
           _currentEntity.Set<T>().Remove(entity);
        }
        public virtual T Get(int id) {
            return _currentEntity.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> GetAll() {
            return _currentEntity.Set<T>().ToList();
        }
        public virtual void Insert(T entity) {
            _currentEntity.Attach<T>(entity).State = EntityState.Added; 
        }
        public virtual void Save() {
            _currentEntity.SaveChanges();
        }
        public virtual void Update( T entity){
            _currentEntity.Attach<T>(entity).State = EntityState.Modified; 
        }
    }
}