using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpmData.Entities;
using OpmImplement.Context;
using OpmInterfaces.Interfaces;

namespace OpmImplement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly OpmContext _context;

        public RoleRepository(OpmContext context)
        {
            _context = context;
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(x => x.RoleId == id);
        }

        public Role CreateRole(Role itemToCreate)
        {
            var role = _context.Roles.Add(itemToCreate);
            _context.SaveChanges();
            return role;
        }

        public IQueryable<Role> Query(Expression<Func<Role, Role>> expression)
        {
            var roles = _context.Roles.Select(expression);
            return roles;
        }

        public IQueryable<Role> Filter(Expression<Func<Role, bool>> expression)
        {
            var roles = _context.Roles.Where(expression);
            return roles;
        }

        public Role Update(Role itemToUpdate)
        {
            _context.Entry(itemToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return itemToUpdate;
        }

        public Role Delete(int id)
        {
            var itemToDelete = GetById(id);
            _context.Roles.Remove(itemToDelete);
            _context.SaveChanges();
            return itemToDelete;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return Query(x => x).ToList();
        }
    }
}
