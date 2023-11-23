﻿using Project_GYM.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GYM.Infrastructure.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeViewModel Map(EmployeeEntity entity)
        {
            var viewModel = new EmployeeViewModel
            {
                EmployeeId = entity.EmployeeId,
                Surname = entity.Surname,
                FirstName = entity.FirstName,
                Patronymic = entity.Patronymic,
                Gender = entity.Gender,
                DateOfBirth = entity.DateOfBirth,
                LengthOfService = entity.LengthOfService.ToString()
            };
            return viewModel;
        }

        public static List<EmployeeViewModel> Map(List<EmployeeEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
    }
}