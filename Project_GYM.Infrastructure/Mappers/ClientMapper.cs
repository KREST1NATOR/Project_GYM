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
                ClientId = entity.ClientId,
                Surname = entity.Surname,
                FirstName = entity.FirstName,
                Patronymic = entity.Patronymic,
                Gender = entity.Gender,
                DateOfBirth = entity.DateOfBirth
            };
            return viewModel;
        }

        public static List<ClientViewModel> Map(List<ClientEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

        public static ClientEntity Map(ClientViewModel viewModel) //Скорее всего неправильно
        {
            var entity = new ClientEntity
            {
                ClientId = viewModel.ClientId,
                Surname = viewModel.Surname,
                FirstName = viewModel.FirstName,
                Patronymic = viewModel.Patronymic,
                Gender = viewModel.Gender,
                DateOfBirth = viewModel.DateOfBirth
            };
            return entity;
        }
    }
}
