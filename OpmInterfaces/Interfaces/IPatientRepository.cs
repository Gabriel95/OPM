using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpmData;

namespace OpmInterfaces.Interfaces
{
    public interface IPatientRepository
    {
        Patient GetById(int id);
        Patient Create(Patient itemToCreate);
        IQueryable<Patient> Query(Expression<Func<Patient, Patient>> expression);
        IQueryable<Patient> Filter(Expression<Func<Patient, bool>> expression);
        Patient Update(Patient itemToUpdate);
        Patient Delete(int id);
        IEnumerable<Patient> GetAllPatients();
    }
}
