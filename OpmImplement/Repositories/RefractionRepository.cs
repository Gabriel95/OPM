using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpmData;
using OpmImplement.Context;
using OpmInterfaces.Interfaces;

namespace OpmImplement.Repositories
{
    public class RefractionRepository : IRefractionRepository
    {
        private readonly OpmContext _context;

        public RefractionRepository(OpmContext context)
        {
            _context = context;
        }

        public Refraction GetById(int id)
        {
            return _context.Refractions.FirstOrDefault(x => x.RefractionId == id);
        }

        public Refraction Create(Refraction itemToCreate)
        {
            var refraction = _context.Refractions.Add(itemToCreate);
            _context.SaveChanges();
            return refraction;
        }

        public IQueryable<Refraction> Query(Expression<Func<Refraction, Refraction>> expression)
        {
            var refractions = _context.Refractions.Select(expression);
            return refractions;
        }

        public IQueryable<Refraction> Filter(Expression<Func<Refraction, bool>> expression)
        {
            var refractions = _context.Refractions.Where(expression);
            return refractions;
        }

        public Refraction Update(Refraction itemToUpdate)
        {
            _context.Entry(itemToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return itemToUpdate;
        }

        public Refraction Delete(int id)
        {
            var itemToDelete = GetById(id);
            _context.Refractions.Remove(itemToDelete);
            _context.SaveChanges();
            return itemToDelete;
        }

        public IEnumerable<Refraction> GetAllRefractions()
        {
            return Query(x => x).ToList();
        }
    }
}
