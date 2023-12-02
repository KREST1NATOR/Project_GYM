﻿using Project_GYM.Infrastructure.Consts;
using Project_GYM.Infrastructure.Database;
using Project_GYM.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_GYM.Windows
{
    /// <summary>
    /// Логика взаимодействия для TrainerCardWindow.xaml
    /// </summary>
    public partial class TrainerCardWindow : Window
    {
        private TrainerViewModel _selectedItem = null;
        private TrainerRepository _repository;
        public TrainerCardWindow()
        {
            InitializeComponent();
        }

        public TrainerCardWindow(TrainerViewModel selectedItem)
        {
            InitializeComponent();
            GrantAccessByRole();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                SurnameTextBox.Text = selectedItem.Surname;
                FirstNameTextBox.Text = selectedItem.FirstName;
                PatronymicTextBox.Text = selectedItem.Patronymic;
                DateOfBirthTextBox.Text = selectedItem.DateOfBirth;
                LengthOfServiceTextBox.Text = selectedItem.LengthOfService;
            }
            else
            {
                _selectedItem = selectedItem;
                SurnameTextBox.Text = null;
                FirstNameTextBox.Text = null;
                PatronymicTextBox.Text = null;
                DateOfBirthTextBox.Text = null;
                LengthOfServiceTextBox.Text = null;
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _repository = new TrainerRepository();
                if (DateOfBirthTextBox.Text.Count() == 10)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new TrainerViewModel
                        {
                            TrainerID = _selectedItem.TrainerID,
                            Surname = SurnameTextBox.Text,
                            FirstName = FirstNameTextBox.Text,
                            Patronymic = PatronymicTextBox.Text,
                            DateOfBirth = DateOfBirthTextBox.Text,
                            LengthOfService = LengthOfServiceTextBox.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Update(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show(".");
                        }
                    }
                    else
                    {
                        var entity = new TrainerViewModel
                        {
                            Surname = SurnameTextBox.Text,
                            FirstName = FirstNameTextBox.Text,
                            Patronymic = PatronymicTextBox.Text,
                            DateOfBirth = DateOfBirthTextBox.Text,
                            LengthOfService = LengthOfServiceTextBox.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Add(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("-");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'День рождения' должно содержать 10 символов");
                }

            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private void GrantAccessByRole()
        {
            if (Application.Current.Resources.Contains(UserInfoConsts.JobTitleId))
            {
                int jobTitleId = Convert.ToInt32(Application.Current.Resources[UserInfoConsts.JobTitleId]);

                if (jobTitleId == 2 || jobTitleId == 4) // Роль администратора 2
                {
                    SaveButton.IsEnabled = false;
                    SurnameTextBox.IsEnabled = false;
                    FirstNameTextBox.IsEnabled = false;
                    PatronymicTextBox.IsEnabled = false;
                    DateOfBirthTextBox.IsEnabled = false;
                    LengthOfServiceTextBox.IsEnabled = false;
                }
                else if (jobTitleId == 5 || jobTitleId == 6) // Роль уборщика
                {
                    SaveButton.IsEnabled = false;
                    SurnameTextBox.IsEnabled = false;
                    FirstNameTextBox.IsEnabled = false;
                    PatronymicTextBox.IsEnabled = false;
                    DateOfBirthTextBox.IsEnabled = false;
                    LengthOfServiceTextBox.IsEnabled = false;
                }
                else if (jobTitleId == 0) // Роль гостя
                {
                    SaveButton.IsEnabled = false;
                    SurnameTextBox.IsEnabled = false;
                    FirstNameTextBox.IsEnabled = false;
                    PatronymicTextBox.IsEnabled = false;
                    DateOfBirthTextBox.IsEnabled = false;
                    LengthOfServiceTextBox.IsEnabled = false;
                }
            }
        }
    }
}
