using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpmData.Entities;

namespace OpmInterfaces.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        User Create(User itemToCreate);
        IQueryable<User> Query(Expression<Func<User, User>> expression);
        IQueryable<User> Filter(Expression<Func<User, bool>> expression);
        User Update(User itemToUpdate);
        User Delete(int id);
        IEnumerable<User> GetAllUsers();
        Role GetUserRole(int id);
    }
}
