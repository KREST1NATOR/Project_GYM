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

        public EmployeeCardWindow()
        {
            InitializeComponent();
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
                JobTitleIdTextBox.Text = selectedItem.JobTitleId;
                LoginTextBox.Text = selectedItem.Login;
                PasswordTextBox.Text = selectedItem.Password;
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
                JobTitleIdTextBox.Text = null;
                LoginTextBox.Text = null;
                PasswordTextBox.Text = null;
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void GrantAccessByRole()
        {
            if (Application.Current.Resources.Contains(UserInfoConsts.JobTitleId))
            {
                int jobTitleId = Convert.ToInt32(Application.Current.Resources[UserInfoConsts.JobTitleId]);

                if (jobTitleId == 1 || jobTitleId == 2 || jobTitleId == 3 || jobTitleId == 4 || jobTitleId == 5 || jobTitleId == 6)
                {
                    SurnameTextBox.IsEnabled = false;
                    FirstNameTextBox.IsEnabled = false;
                    PatronymicTextBox.IsEnabled = false;
                    GenderTextBox.IsEnabled = false;
                    DateOfBirthTextBox.IsEnabled = false;
                    LengthOfServiceTextBox.IsEnabled = false;
                    JobTitleIdTextBox.IsEnabled = false;
                    LoginTextBox.IsEnabled = false;
                    PasswordTextBox.IsEnabled = false;
                }
            }
        }
    }
}
