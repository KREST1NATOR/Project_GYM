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
using Project_GYM.Infrastructure;

namespace Project_GYM.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientCardWindow.xaml
    /// </summary>
    public partial class ClientCardWindow : Window
    {
        private ClientViewModel _selectedItem = null;
        private ClientRepository _repository;
        private GymRepository _gymRepository;
        private DiscountRepository _discountRepository;
        public ClientCardWindow()
        {
            InitializeComponent();
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            _gymRepository = new GymRepository(new Context());
            _discountRepository = new DiscountRepository(new Context());

            GymComboBox.ItemsSource = _gymRepository.GetGyms();
            DiscountComboBox.ItemsSource = _discountRepository.GetDiscounts();
        }
        private void GenderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GenderTextBox.Text == "М или Ж")
            {
                GenderTextBox.Text = "";
                GenderTextBox.Foreground = Brushes.DarkGray;
            }
        }

        private void GenderTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GenderTextBox.Text))
            {
                GenderTextBox.Text = "М или Ж";
                GenderTextBox.Foreground = Brushes.DarkGray;
            }
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
                var selectedGymId = (long)GymComboBox.SelectedValue;
                var selectedDiscountId = (long)DiscountComboBox.SelectedValue;

                var entity = new ClientViewModel
                {
                    Surname = SurnameTextBox.Text,
                    FirstName = FirstNameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    Gender = GenderTextBox.Text,
                    DateOfBirth = DateOfBirthTextBox.Text,
                    IdGym = selectedGymId,
                    DiscountId = selectedDiscountId
                };

                _repository = new ClientRepository();
                _repository.Add(entity);
                Window.GetWindow(this).Close();
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены!");
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
