using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.Database
{
    public class SubscriptionTypeRepository
    {
        public List<SubscriptionTypeViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.SubscriptionTypes.ToList();
                return SubscriptionTypeMapper.Map(items);
            }
        }
        public SubscriptionTypeViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.SubscriptionTypes.FirstOrDefault(x => x.SubscriptionTypeId == id);
                return SubscriptionTypeMapper.Map(item);
            }
        }
    }
}
