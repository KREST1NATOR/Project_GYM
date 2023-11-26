﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project_GYM.Infrastructure.Database;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;
using Project_GYM.Windows;

namespace Project_GYM.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private ClientRepository _repository;
        public ClientsPage()
        {
            InitializeComponent();
            _repository = new ClientRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            ClientsDataGrid.ItemsSource = _repository.GetList();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        private void ClientsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var item = ClientsDataGrid.SelectedItem as ClientViewModel;
            if (item == null)
            {
                MessageBox.Show("-");
            }
            else
            {
                var ClientId = item.ClientId;
                mainWindow.Hide();
                var clientCard = new ClientCardWindow(ClientsDataGrid.SelectedItem as ClientViewModel);
                clientCard.ShowDialog();
                UpdateGrid();
                mainWindow.Show();
            }
        }
        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var clientCard = new ClientCardWindow();
            clientCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }
        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = ClientsDataGrid.SelectedItem as ClientViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.ClientId);
                UpdateGrid();
            }
        }
        private void UpdateClientsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }
    }
}
