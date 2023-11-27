using Project_GYM.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.Mappers
{
    public static class SubscriptionTypeMapper
    {
        public static SubscriptionTypeViewModel Map(SubscriptionTypeEntity entity)
        {
            var viewModel = new SubscriptionTypeViewModel
            {
                SubscriptionTypeId = entity.SubscriptionTypeId,
                Name = entity.Name,
                Cost = entity.Cost,
                Term = entity.Term
            };
            return viewModel;
        }
        public static List<SubscriptionTypeViewModel> Map(List<SubscriptionTypeEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static SubscriptionTypeEntity Map(SubscriptionTypeViewModel viewModel)
        {
            var entity = new SubscriptionTypeEntity
            {
                SubscriptionTypeId = viewModel.SubscriptionTypeId,
                Name = viewModel.Name,
                Cost = viewModel.Cost,
                Term = viewModel.Term
            };
            return entity;
        }
    }
}
