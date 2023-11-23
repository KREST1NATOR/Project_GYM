using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;

namespace Project_GYM.Infrastructure.Database
{
    public class TrainerRepository
    {
        public List<TrainerViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Trainers.ToList();
                return TrainerMapper.Map(items);
            }
        }
        public TrainerViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Trainers.FirstOrDefault(x => x.TrainerID == id);
                return TrainerMapper.Map(item);
            }
        }
    }
}
