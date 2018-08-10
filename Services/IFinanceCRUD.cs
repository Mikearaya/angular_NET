
using System.Collections.Generic;

namespace angularNet.Services {


public  interface  IFinanceCRUD<T> where T: class {

      IEnumerable<T> GetAll();
      T Get(int id);
      void Insert(T entity);
      void Update(T entity);
      void Delete(T entity);
      void Save();
    
    }
}