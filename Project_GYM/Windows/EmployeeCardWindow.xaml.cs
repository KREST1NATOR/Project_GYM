using Project_GYM.Infrastructure;
using Project_GYM.Infrastructure.Consts;
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
        private EmployeeRepository _employeeRepository;
        private GymRepository _gymRepository;
        private JobTitleRepository _jobTitleRepository;
        public EmployeeCardWindow()
        {
            InitializeComponent();
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            _gymRepository = new GymRepository(new Context());
            _jobTitleRepository = new JobTitleRepository(new Context());

            GymComboBox.ItemsSource = _gymRepository.GetGyms();
            JobTitleComboBox.ItemsSource = _jobTitleRepository.GetJobTitles();
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
        public EmployeeCardWindow(EmployeeViewModel selectedItem)
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
                LengthOfServiceTextBox.Text = selectedItem.LengthOfService;
            }
            else
            {
                _selectedItem = selectedItem;
                SurnameTextBox.Text = null;
                FirstNameTextBox.Text = null;
                PatronymicTextBox.Text = null;
                GenderTextBox.Text = null;
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
                var selectedGymId = (long)GymComboBox.SelectedValue;
                var selectedJobTitleId = (long)JobTitleComboBox.SelectedValue;

                var employee = new EmployeeViewModel
                {
                    Surname = SurnameTextBox.Text,
                    FirstName = FirstNameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    Gender = GenderTextBox.Text,
                    DateOfBirth = DateOfBirthTextBox.Text,
                    LengthOfService = LengthOfServiceTextBox.Text,
                    IdGym = selectedGymId,
                    JobTitleId = selectedJobTitleId
                };

                _employeeRepository = new EmployeeRepository();
                _employeeRepository.Add(employee);
                Window.GetWindow(this).Close();
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены или заполнены неверно!");
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
                    LengthOfServiceTextBox.IsEnabled = false;
                }
                else if (jobTitleId == 5 || jobTitleId == 6) // Роль уборщика
                {
                    SaveButton.IsEnabled = false;
                    SurnameTextBox.IsEnabled = false;
                    FirstNameTextBox.IsEnabled = false;
                    PatronymicTextBox.IsEnabled = false;
                    GenderTextBox.IsEnabled = false;
                    DateOfBirthTextBox.IsEnabled = false;
                    LengthOfServiceTextBox.IsEnabled = false;
                }
            }
        }
    }
}
