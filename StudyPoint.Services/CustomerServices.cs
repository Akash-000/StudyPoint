using PagedList;
using StudyPoint.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPoint.Services
{
    public class CustomerServices
    {
        StudyPointContext _context;
        public CustomerServices()
        {
            _context = new StudyPointContext();
        }

        public StudyPointUsers GetCustomer(string Id)
        {
            return _context.Users.SingleOrDefault(c => c.Id == Id);
        }

        public IPagedList<StudyPointUsers> GetAllCustomers(int? Page)
        {
            return _context.Users.ToList().ToPagedList(Page ?? 1, 5);
        }
    }
}
