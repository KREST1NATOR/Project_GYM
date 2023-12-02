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
    /// Логика взаимодействия для SubscriptionCardWindow.xaml
    /// </summary>
    public partial class SubscriptionCardWindow : Window
    {
        private SubscriptionTypeViewModel _selectedItem = null;
        private SubscriptionTypeRepository _repository;
        public SubscriptionCardWindow()
        {
            InitializeComponent();
        }

        public SubscriptionCardWindow(SubscriptionTypeViewModel selectedItem)
        {
            InitializeComponent();
            GrantAccessByRole();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                NameTextBox.Text = selectedItem.Name;
                CostTextBox.Text = selectedItem.Cost.ToString();
                TermTextBox.Text = selectedItem.Term.ToString();
            }
            else
            {
                _selectedItem = selectedItem;
                NameTextBox.Text = null;
                CostTextBox.Text = null;
                TermTextBox.Text = null;
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
                _repository = new SubscriptionTypeRepository();
                if (NameTextBox.Text.Count() != 0)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new SubscriptionTypeViewModel
                        {
                            SubscriptionTypeId = _selectedItem.SubscriptionTypeId,
                            Name = NameTextBox.Text,
                            Cost = Convert.ToDecimal(CostTextBox.Text),
                            Term = Convert.ToDecimal(TermTextBox.Text),
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
                        var entity = new SubscriptionTypeViewModel
                        {
                            Name = NameTextBox.Text,
                            Cost = Convert.ToDecimal(CostTextBox.Text),
                            Term = Convert.ToDecimal(TermTextBox.Text),
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
                    NameTextBox.IsEnabled = false;
                    CostTextBox.IsEnabled = false;
                    TermTextBox.IsEnabled = false;
                }
                else if (jobTitleId == 5 || jobTitleId == 6) // Роль уборщика
                {
                    SaveButton.IsEnabled = false;
                    NameTextBox.IsEnabled = false;
                    CostTextBox.IsEnabled = false;
                    TermTextBox.IsEnabled = false;
                }
                else if (jobTitleId == 0) // Роль гостя
                {
                    SaveButton.IsEnabled = false;
                    NameTextBox.IsEnabled = false;
                    CostTextBox.IsEnabled = false;
                    TermTextBox.IsEnabled = false;
                }
            }
        }
    }
}
