using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.Database
{
    public class DiscountRepository
    {
        private readonly Context _context;

        public DiscountRepository(Context context)
        {
            _context = context;
        }

        public List<DiscountEntity> GetDiscounts()
        {
            return _context.Discounts.ToList();
        }
    }
}
