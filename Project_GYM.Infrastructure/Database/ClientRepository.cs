using System;
using System.Collections.Generic;
using System.Linq;
using Project_GYM.Infrastructure.ViewModels;
using Project_GYM.Infrastructure.Mappers;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public ClientViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Clients.FirstOrDefault(x => x.ClientId == id);
                return ClientMapper.Map(item);
            }
        }
        public ClientViewModel Add(ClientViewModel entity)
        {
            entity.Surname = entity.Surname.Trim();
            entity.FirstName = entity.FirstName.Trim();
            entity.Patronymic = entity.Patronymic.Trim();
            entity.Gender = entity.Gender.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            if (string.IsNullOrEmpty(entity.Surname) || string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.Gender) || string.IsNullOrEmpty(entity.DateOfBirth))
            {
                MessageBox.Show("Поля, кроме отчества, не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = ClientMapper.Map(entity);
                context.Clients.Add(item);
                if (item != null)
                {
                    item.Surname = entity.Surname;
                    item.FirstName = entity.FirstName;
                    item.Patronymic = entity.Patronymic;
                    item.Gender = entity.Gender;
                    item.DateOfBirth = entity.DateOfBirth;
                    context.Clients.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ClientMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.Clients.FirstOrDefault(x => x.ClientId == id);
                if (user != null)
                {
                    context.Clients.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public ClientViewModel Update(ClientViewModel entity)
        {
            entity.Surname = entity.Surname.Trim();
            entity.FirstName = entity.FirstName.Trim();
            entity.Gender = entity.Gender.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            if (string.IsNullOrEmpty(entity.Surname) || string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.Gender) || string.IsNullOrEmpty(entity.DateOfBirth))
                MessageBox.Show("Поля, кроме отчества, не могут быть пустыми");

            using (var context = new Context())
            {
                var item = context.Clients.FirstOrDefault(x => x.ClientId == entity.ClientId);
                if (item != null)
                {
                    item.Surname = entity.Surname;
                    item.FirstName = entity.FirstName;
                    item.Patronymic = entity.Patronymic;
                    item.Gender = entity.Gender;
                    item.DateOfBirth = entity.DateOfBirth;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ClientMapper.Map(item);
            }
        }
        public List<ClientViewModel> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Поисковый запрос не может быть пустым.");
            }

            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Clients
                    .Where(x => x.Surname.ToLower().Contains(search) || x.FirstName.ToLower().Contains(search) || x.Patronymic.ToLower().Contains(search))
                    .ToList();

                return ClientMapper.Map(result);
            }
        }
    }
}
