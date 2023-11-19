using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_GYM.Infrastructure.ViewModels;
using Project_GYM.Infrastructure.Database;

namespace Project_GYM.Infrastructure.Mappers
{
    public static class ClientMapper
    {
        public static ClientViewModel Map(ClientEntity entity)
        {
            var viewModel = new ClientViewModel
            {
                Surname = entity.Surname,
                First_name = entity.First_name,
                Patronymic = entity.Patronymic,
                Gender = entity.Gender,
                Date_of_birth = entity.Date_of_birth
            };
            return viewModel;
        }

        public static List<ClientViewModel> Map(List<ClientEntity> entities)
        {
            var viewModels = entities.Select(x => x.Map).ToList();
            return viewModels;
        }

    }
}
