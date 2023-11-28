using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;
using System.Windows;
using System.Data.Entity;

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
                    item.LengthOfService = Convert.ToDecimal(entity.LengthOfService);
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
                    item.LengthOfService = Convert.ToDecimal(entity.LengthOfService);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return EmployeeMapper.Map(item);
            }
        }
        public EmployeeViewModel ValidateAndGetUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Логин и пароль должны быть заполнены.");
            }

            if (login.Length > 100 || password.Length > 25)
            {
                throw new ArgumentException("Логин и пароль не могут быть длиннее 25 символов.");
            }

            if (!login.All(char.IsLetterOrDigit) || !password.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Логин и пароль могут содержать только буквы и цифры.");
            }

            using (var context = new Context())
            {
                var item = context.Employees
                    .Include(x => x.JobTitle)
                    .FirstOrDefault(e => e.Login == login && e.Password == password);

                return EmployeeMapper.Map(item);
            }
        }
        public List<EmployeeViewModel> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentException("Поисковый запрос не может быть пустым.");
            }

            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Employees
                    .Where(x => x.Surname.Contains(search) || x.FirstName.Contains(search) || x.Patronymic.Contains(search))
                    .ToList();

                return EmployeeMapper.Map(result);
            }
        }
    }
}
