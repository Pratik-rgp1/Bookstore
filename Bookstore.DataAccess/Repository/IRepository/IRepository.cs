using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //A generic repository that can handle different entity types.(<T> means its generic)
    {
        //T - Category
        IEnumerable<T> GetAll(); //Retrieves all records from the database.
        T Get(Expression<Func<T, bool>> filter); //Retrieves a single record that matches a given condition.
        void Add(T entity); //Adds a new entity to the database.
        void Update(T entity); //Updates an existing entity.
        void Remove(T entity); //Deletes a single entity.
        void RemoveRange(IEnumerable<T> entity); //Deletes multiple entities at once.

    }
    
}
