using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;

namespace Project_GYM.Infrastructure.Database
{
    public class EmployeeRepository
    {
        public List<EmployeeViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Employees.ToList();
                return EmployeeMapper.Map(items);
            }
        }
        public EmployeeViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                return EmployeeMapper.Map(item);
            }
        }
        public EmployeeViewModel Add(EmployeeViewModel entity)
        {
            entity.Surname = entity.Surname.Trim();
            entity.FirstName = entity.FirstName.Trim();
            entity.Patronymic = entity.Patronymic.Trim();
            entity.Gender = entity.Gender.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            entity.LengthOfService = entity.LengthOfService;
            if (string.IsNullOrEmpty(entity.Surname) || string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.Gender) || string.IsNullOrEmpty(entity.DateOfBirth) || string.IsNullOrEmpty(entity.LengthOfService))
            {
                throw new Exception("Поля, кроме отчества, не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = EmployeeMapper.Map(entity);
                context.Employees.Add(item);
                if (item != null)
                {
                    item.Surname = entity.Surname;
                    item.FirstName = entity.FirstName;
                    item.Patronymic = entity.Patronymic;
                    item.Gender = entity.Gender;
                    item.DateOfBirth = entity.DateOfBirth;
                    //item.LengthOfService = entity.LengthOfService.ToString();
                    context.Employees.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return EmployeeMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (user != null)
                {
                    context.Employees.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public EmployeeViewModel Update(EmployeeViewModel entity)
        {
            entity.Surname = entity.Surname.Trim();
            entity.FirstName = entity.FirstName.Trim();
            entity.Gender = entity.Gender.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            entity.LengthOfService = entity.LengthOfService;
            if (string.IsNullOrEmpty(entity.Surname) || string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.Gender) || string.IsNullOrEmpty(entity.DateOfBirth) || string.IsNullOrEmpty(entity.LengthOfService))
                MessageBox.Show("Поля, кроме отчества, не могут быть пустыми");

            using (var context = new Context())
            {
                var item = context.Employees.FirstOrDefault(x => x.EmployeeId == entity.EmployeeId);
                if (item != null)
                {
                    item.Surname = entity.Surname;
                    item.FirstName = entity.FirstName;
                    item.Gender = entity.Gender.Trim();
                    item.DateOfBirth = entity.DateOfBirth;
                    //item.LengthOfService = entity.LengthOfService.ToString();
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return EmployeeMapper.Map(item);
            }
        }
    }
}
