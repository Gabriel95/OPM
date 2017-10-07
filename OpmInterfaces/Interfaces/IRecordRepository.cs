using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpmData;

namespace OpmInterfaces.Interfaces
{
    public interface IRecordRepository
    {
        Record GetById(int id);
        Record Create(Record itemToCreate);
        IQueryable<Record> Query(Expression<Func<Record, Record>> expression);
        IQueryable<Record> Filter(Expression<Func<Record, bool>> expression);
        Record Update(Record itemToUpdate);
        Record Delete(int id);
        IEnumerable<Record> GetAllRecords();
        IEnumerable<Record> GetAllRecordsByPatientId(int id);
    }
}
