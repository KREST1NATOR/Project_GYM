using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;

namespace Project_GYM.Infrastructure.Database
{
    public class ClientRepository
    {
        public List<ClientViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Clients.ToList();
                return ClientMapper.Map(items);
            }
        }

    }
}
