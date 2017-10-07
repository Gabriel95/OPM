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
    public class PatientRepository : IPatientRepository
    {
        private readonly OpmContext _context;

        public PatientRepository(OpmContext context)
        {
            _context = context;
        }

        public Patient GetById(int id)
        {
            return _context.Patients.FirstOrDefault(x => x.PatientId == id);
        }

        public Patient Create(Patient itemToCreate)
        {
            var patient = _context.Patients.Add(itemToCreate);
            _context.SaveChanges();
            return patient;
        }

        public IQueryable<Patient> Query(Expression<Func<Patient, Patient>> expression)
        {
            var patients = _context.Patients.Select(expression);
            return patients;
        }

        public IQueryable<Patient> Filter(Expression<Func<Patient, bool>> expression)
        {
            var patients = _context.Patients.Where(expression);
            return patients;
        }

        public Patient Update(Patient itemToUpdate)
        {
            _context.Entry(itemToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return itemToUpdate;
        }

        public Patient Delete(int id)
        {
            var itemToDelete = GetById(id);
            _context.Patients.Remove(itemToDelete);
            _context.SaveChanges();
            return itemToDelete;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return Query(x => x).ToList();
        }
    }
}
