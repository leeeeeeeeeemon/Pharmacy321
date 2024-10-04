using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class DBManager
    {
        private static Pharmacy_MDKEntities _context = new Pharmacy_MDKEntities(); 
        public static Pharmacy_MDKEntities GetContext()
        {
            if (_context == null)
                _context = new Pharmacy_MDKEntities(); return _context;
        }
        public static bool UpdateDatabase()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<Sotrydniki> GetStaff()
        {
            return _context.Sotrydniki.ToList();
        }
    }
}
