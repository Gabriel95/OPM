using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpmData;

namespace OpmInterfaces.Interfaces
{
    public interface IRefractionRepository
    {
        Refraction GetById(int id);
        Refraction Create(Refraction itemToCreate);
        IQueryable<Refraction> Query(Expression<Func<Refraction, Refraction>> expression);
        IQueryable<Refraction> Filter(Expression<Func<Refraction, bool>> expression);
        Refraction Update(Refraction itemToUpdate);
        Refraction Delete(int id);
        IEnumerable<Refraction> GetAllRefractions();
    }
}
