using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.ViewModels
{
    public class SubscriptionTypeViewModel
    {
        public long SubscriptionTypeId { get; set; }
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public decimal Term { get; set; }
    }
}
