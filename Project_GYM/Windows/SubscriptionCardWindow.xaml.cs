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
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                Name.Text = selectedItem.Name;
                Cost.Text = selectedItem.Cost.ToString();
                Term.Text = selectedItem.Term.ToString();
            }
            else
            {
                _selectedItem = selectedItem;
                Name.Text = null;
                Cost.Text = null;
                Term.Text = null;
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
                if (Name.Text.Count() != 0)
                {
                    if (_selectedItem != null)
                    {
                        var entity = new SubscriptionTypeViewModel
                        {
                            SubscriptionTypeId = _selectedItem.SubscriptionTypeId,
                            Name = Name.Text,
                            Cost = Convert.ToDecimal(Cost.Text),
                            Term = Convert.ToDecimal(Term.Text),
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
                            Name = Name.Text,
                            Cost = Convert.ToDecimal(Cost.Text),
                            Term = Convert.ToDecimal(Term.Text),
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
