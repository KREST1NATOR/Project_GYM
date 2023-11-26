﻿using System;
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
        public TrainerViewModel Add(TrainerViewModel entity)
        {
            entity.Surname = entity.Surname.Trim();
            entity.FirstName = entity.FirstName.Trim();
            entity.Patronymic = entity.Patronymic.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            entity.LengthOfService = entity.LengthOfService;
            if (string.IsNullOrEmpty(entity.Surname) || string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.DateOfBirth) || string.IsNullOrEmpty(entity.LengthOfService))
            {
                throw new Exception("Поля, кроме отчества, не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = TrainerMapper.Map(entity);
                context.Trainers.Add(item);
                if (item != null)
                {
                    item.Surname = entity.Surname;
                    item.FirstName = entity.FirstName;
                    item.Patronymic = entity.Patronymic;
                    item.DateOfBirth = entity.DateOfBirth;
                    //item.LengthOfService = entity.LengthOfService.ToString();
                    context.Trainers.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return TrainerMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.Trainers.FirstOrDefault(x => x.TrainerID == id);
                if (user != null)
                {
                    context.Trainers.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public TrainerViewModel Update(TrainerViewModel entity)
        {
            entity.Surname = entity.Surname.Trim();
            entity.FirstName = entity.FirstName.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            entity.LengthOfService = entity.LengthOfService;
            if (string.IsNullOrEmpty(entity.Surname) || string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.DateOfBirth) || string.IsNullOrEmpty(entity.LengthOfService))
                MessageBox.Show("Поля, кроме отчества, не могут быть пустыми");

            using (var context = new Context())
            {
                var item = context.Trainers.FirstOrDefault(x => x.TrainerID == entity.TrainerID);
                if (item != null)
                {
                    item.Surname = entity.Surname;
                    item.FirstName = entity.FirstName;
                    item.Patronymic = entity.Patronymic;
                    item.DateOfBirth = entity.DateOfBirth;
                    //item.LengthOfService = entity.LengthOfService.ToString();
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return TrainerMapper.Map(item);
            }
        }
    }
}
