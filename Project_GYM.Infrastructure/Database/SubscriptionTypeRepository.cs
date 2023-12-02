using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_GYM.Infrastructure.Database
{
    public class SubscriptionTypeRepository
    {
        public List<SubscriptionTypeViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.SubscriptionTypes.ToList();
                return SubscriptionTypeMapper.Map(items);
            }
        }
        public SubscriptionTypeViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.SubscriptionTypes.FirstOrDefault(x => x.SubscriptionTypeId == id);
                return SubscriptionTypeMapper.Map(item);
            }
        }
        public SubscriptionTypeViewModel Add(SubscriptionTypeViewModel entity)
        {
            entity.Name = entity.Name.Trim();
            entity.Cost = entity.Cost;
            entity.Term = entity.Term;
            if (string.IsNullOrEmpty(entity.Name))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = SubscriptionTypeMapper.Map(entity);
                context.SubscriptionTypes.Add(item);
                if (item != null)
                {
                    item.Name = entity.Name;
                    item.Cost = entity.Cost;
                    item.Term = entity.Term;
                    context.SubscriptionTypes.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return SubscriptionTypeMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.SubscriptionTypes.FirstOrDefault(x => x.SubscriptionTypeId == id);
                if (user != null)
                {
                    context.SubscriptionTypes.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public SubscriptionTypeViewModel Update(SubscriptionTypeViewModel entity)
        {
            entity.Name = entity.Name.Trim();
            entity.Cost = entity.Cost;
            entity.Term = entity.Term;
            if (string.IsNullOrEmpty(entity.Name))
                MessageBox.Show("Поля, кроме отчества, не могут быть пустыми");

            using (var context = new Context())
            {
                var item = context.SubscriptionTypes.FirstOrDefault(x => x.SubscriptionTypeId == entity.SubscriptionTypeId);
                if (item != null)
                {
                    item.Name = entity.Name;
                    item.Cost = entity.Cost;
                    item.Term = entity.Term;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return SubscriptionTypeMapper.Map(item);
            }
        }
        public List<SubscriptionTypeViewModel> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Поисковый запрос не может быть пустым.");
            }

            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.SubscriptionTypes
                    .Where(x => x.Name.ToLower().Contains(search))
                    .ToList();

                return SubscriptionTypeMapper.Map(result);
            }
        }
    }
}
