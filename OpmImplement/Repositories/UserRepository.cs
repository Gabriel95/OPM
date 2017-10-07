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
    public class UserRepository : IUserRepository
    {
        private readonly OpmContext _context;

        public UserRepository(OpmContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public User Create(User itemToCreate)
        {
            var user = _context.Users.Add(itemToCreate);
            _context.SaveChanges();
            return user;
        }

        public IQueryable<User> Query(Expression<Func<User, User>> expression)
        {
            var myUsers = _context.Users.Select(expression);
            return myUsers;
        }

        public IQueryable<User> Filter(Expression<Func<User, bool>> expression)
        {
            var myUsers = _context.Users.Where(expression);
            return myUsers;
        }

        public User Update(User itemToUpdate)
        {
            _context.Entry(itemToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return itemToUpdate;
        }

        public User Delete(int id)
        {
            var itemToDelete = GetById(id);
            _context.Users.Remove(itemToDelete);
            _context.SaveChanges();
            return itemToDelete;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Query(x => x).ToList();
        }

        public Role GetUserRole(int id)
        {
            throw new NotImplementedException();
        }
    }
}
