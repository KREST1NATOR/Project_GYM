using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Project_GYM.Infrastructure.Database
{
    public class GymRepository
    {
        private readonly Context _context;

        public GymRepository(Context context)
        {
            _context = context;
        }

        public List<GymEntity> GetGyms()
        {
            return _context.Gyms.ToList();
        }
    }
}
