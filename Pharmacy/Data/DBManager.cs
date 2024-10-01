using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class DBManager
    {
        private static PharmacyEntities _context = new PharmacyEntities();
        public static PharmacyEntities GetContext()
        {
            if (_context == null)
                _context = new PharmacyEntities();
            return _context;
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

        public static List<Sotrudnik> GetStaff()
        {
            return _context.Sotrudnik.ToList();
        }

        public static List<Klient> GetClients()
        {
            return _context.Klient.ToList();
        }

        public static List<Zapis_priem> GetAppointments()
        {
            return _context.Zapis_priem.ToList();
        }

        public static bool MakeAppointment(Zapis_priem appointment)
        {
            try
            {
                _context.Zapis_priem.Add(appointment);
                UpdateDatabase();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
