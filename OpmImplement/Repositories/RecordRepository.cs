using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OpmData;
using OpmImplement.Context;
using OpmInterfaces.Interfaces;
namespace OpmImplement.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly OpmContext _context;

        public RecordRepository(OpmContext context)
        {
            _context = context;
        }

        public Record GetById(int id)
        {
            return _context.Records.FirstOrDefault(x => x.RecordId == id);
        }

        public Record Create(Record itemToCreate)
        {
            var record = _context.Records.Add(itemToCreate);
            _context.SaveChanges();
            return record;
        }

        public IQueryable<Record> Query(Expression<Func<Record, Record>> expression)
        {
            var records = _context.Records.Select(expression);
            return records;
        }

        public IQueryable<Record> Filter(Expression<Func<Record, bool>> expression)
        {
            var records = _context.Records.Where(expression);
            return records;
        }

        public Record Update(Record itemToUpdate)
        {
            _context.Entry(itemToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return itemToUpdate;
        }

        public Record Delete(int id)
        {
            var itemToDelete = GetById(id);
            _context.Records.Remove(itemToDelete);
            _context.SaveChanges();
            return itemToDelete;
        }

        public IEnumerable<Record> GetAllRecords()
        {
            return Query(x => x).ToList();
        }

        public IEnumerable<Record> GetAllRecordsByPatientId(int id)
        {
            return Filter(x => x.Patient.PatientId == id).ToList();
        }
    }
}
