using Project_GYM.Infrastructure.Database;
using Project_GYM.Infrastructure.ViewModels;
using Project_GYM.Infrastructure.Mappers;
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
using Project_GYM.Infrastructure.Consts;

namespace Project_GYM.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientCardWindow.xaml
    /// </summary>
    public partial class ClientCardWindow : Window
    {
        private ClientViewModel _selectedItem = null;
        private ClientRepository _repository;
        public ClientCardWindow()
        {
            InitializeComponent();
        }

        public ClientCardWindow(ClientViewModel selectedItem)
        {
            InitializeComponent();
            GrantAccessByRole();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                SurnameTextBox.Text = selectedItem.Surname;
                FirstNameTextBox.Text = selectedItem.FirstName;
                PatronymicTextBox.Text = selectedItem.Patronymic;
                GenderTextBox.Text = selectedItem.Gender;
                DateOfBirthTextBox.Text = selectedItem.DateOfBirth;
            }
            else
            {
                _selectedItem = selectedItem;
                SurnameTextBox.Text = null;
                FirstNameTextBox.Text = null;
                PatronymicTextBox.Text = null;
                GenderTextBox.Text = null;
                DateOfBirthTextBox.Text = null;
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
                _repository = new ClientRepository();
                if (DateOfBirthTextBox.Text.Count() == 10)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new ClientViewModel
                        {
                            ClientId = _selectedItem.ClientId,
                            Surname = SurnameTextBox.Text,
                            FirstName = FirstNameTextBox.Text,
                            Patronymic = PatronymicTextBox.Text,
                            Gender = GenderTextBox.Text,
                            DateOfBirth = DateOfBirthTextBox.Text,
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
                        var entity = new ClientViewModel
                        {
                            Surname = SurnameTextBox.Text,
                            FirstName = FirstNameTextBox.Text,
                            Patronymic = PatronymicTextBox.Text,
                            Gender = GenderTextBox.Text,
                            DateOfBirth = DateOfBirthTextBox.Text,
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
                    GenderTextBox.IsEnabled = false;
                    DateOfBirthTextBox.IsEnabled = false;
                }
            }
        }
    }
}
