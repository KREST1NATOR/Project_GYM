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
    /// Логика взаимодействия для EmployeeCardWindow.xaml
    /// </summary>
    public partial class EmployeeCardWindow : Window
    {
        private EmployeeViewModel _selectedItem = null;
        private EmployeeRepository _repository;
        public EmployeeCardWindow()
        {
            InitializeComponent();
        }

        public EmployeeCardWindow(EmployeeViewModel selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                Surname.Text = selectedItem.Surname;
                FirstName.Text = selectedItem.FirstName;
                Patronymic.Text = selectedItem.Patronymic;
                Gender.Text = selectedItem.Gender;
                DateOfBirth.Text = selectedItem.DateOfBirth;
                LengthOfService.Text = selectedItem.LengthOfService;
            }
            else
            {
                _selectedItem = selectedItem;
                Surname.Text = null;
                FirstName.Text = null;
                Patronymic.Text = null;
                Gender.Text = null;
                DateOfBirth.Text = null;
                LengthOfService.Text = null;
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
                _repository = new EmployeeRepository();
                if (DateOfBirth.Text.Count() == 10)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new EmployeeViewModel
                        {
                            EmployeeId = _selectedItem.EmployeeId,
                            Surname = Surname.Text,
                            FirstName = FirstName.Text,
                            Patronymic = Patronymic.Text,
                            Gender = Gender.Text,
                            DateOfBirth = DateOfBirth.Text,
                            LengthOfService = LengthOfService.Text,
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
                        var entity = new EmployeeViewModel
                        {
                            Surname = Surname.Text,
                            FirstName = FirstName.Text,
                            Patronymic = Patronymic.Text,
                            Gender = Gender.Text,
                            DateOfBirth = DateOfBirth.Text,
                            LengthOfService = LengthOfService.Text,
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
    }
}
