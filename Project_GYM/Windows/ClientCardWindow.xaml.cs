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
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                Surname.Text = selectedItem.Surname;
                FirstName.Text = selectedItem.FirstName;
                Patronymic.Text = selectedItem.Patronymic;
                Gender.Text = selectedItem.Gender;
                DateOfBirth.Text = selectedItem.DateOfBirth;
            }
            else
            {
                _selectedItem = selectedItem;
                Surname.Text = null;
                FirstName.Text = null;
                Patronymic.Text = null;
                Gender.Text = null;
                DateOfBirth.Text = null;
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
                if (DateOfBirth.Text.Count() == 10)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new ClientViewModel
                        {
                            ClientId = _selectedItem.ClientId,
                            Surname = Surname.Text,
                            FirstName = FirstName.Text,
                            Patronymic = Patronymic.Text,
                            Gender = Gender.Text,
                            DateOfBirth = DateOfBirth.Text,
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
                            Surname = Surname.Text,
                            FirstName = FirstName.Text,
                            Patronymic = Patronymic.Text,
                            Gender = Gender.Text,
                            DateOfBirth = DateOfBirth.Text,
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
