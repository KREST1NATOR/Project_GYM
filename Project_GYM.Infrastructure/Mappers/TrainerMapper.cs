using Project_GYM.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.Mappers
{
    public static class TrainerMapper
    {
        public static TrainerViewModel Map(TrainerEntity entity)
        {
            var viewModel = new TrainerViewModel
            {
                TrainerID = entity.TrainerID,
                Surname = entity.Surname,
                FirstName = entity.FirstName,
                Patronymic = entity.Patronymic,
                DateOfBirth = entity.DateOfBirth,
                LengthOfService = entity.LengthOfService.ToString()
            };
            return viewModel;
        }

        public static List<TrainerViewModel> Map(List<TrainerEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static TrainerEntity Map(TrainerViewModel viewModel)
        {
            var entity = new TrainerEntity
            {
                TrainerID = viewModel.TrainerID,
                Surname = viewModel.Surname,
                FirstName = viewModel.FirstName,
                Patronymic = viewModel.Patronymic,
                DateOfBirth = viewModel.DateOfBirth,
                LengthOfService = Convert.ToDecimal(viewModel.LengthOfService),
            };
            return entity;
        }
    }
}
