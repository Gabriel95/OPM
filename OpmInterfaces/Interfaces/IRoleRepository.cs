using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpmData.Entities;

namespace OpmInterfaces.Interfaces
{
    public interface IRoleRepository
    {
        Role GetById(int id);
        Role CreateRole(Role itemToCreate);
        IQueryable<Role> Query(Expression<Func<Role, Role>> expression);
        IQueryable<Role> Filter(Expression<Func<Role, bool>> expression);
        Role Update(Role itemToUpdate);
        Role Delete(int id);
        IEnumerable<Role> GetAllRoles();
    }
}
