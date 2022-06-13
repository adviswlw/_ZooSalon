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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZooSalon.Administration
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    AdZooSalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridClients.ItemsSource = AdZooSalonEntities.GetContext().Clients.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка обновления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private DateTime birthdayOut;
        private DateTime regDateOut;
        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime.TryParse(txtBoxSearch.Text, out birthdayOut);
            DateTime.TryParse(txtBoxSearch.Text, out regDateOut);
            try
            {
                List<Client> currentClient = AdZooSalonEntities.GetContext().Clients.ToList();
                currentClient = currentClient.Where(p => p.FirstName.ToLower().Contains(txtBoxSearch.Text.ToLower()) ||
                p.LastName.ToLower().Contains(txtBoxSearch.Text.ToLower()) ||
                p.Patronymic.ToLower().Contains(txtBoxSearch.Text.ToLower()) ||
                p.Email.ToLower().Contains(txtBoxSearch.Text.ToLower()) ||
                p.Phone.ToString().Contains(txtBoxSearch.Text.ToLower()) ||
                p.Birthday.Equals(birthdayOut) ||
                p.RegistrationDate.Equals(regDateOut)).ToList();
                DGridClients.ItemsSource = currentClient.ToList();
                if (currentClient.Count == 0)
                {
                    lblNothingFound.Visibility = Visibility.Visible;
                }
                else
                {
                    lblNothingFound.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка обновления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new AddEditClientPage(null));
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (DGridClients.SelectedItems.Count > 0)
            {
                var clientsForRemove = DGridClients.SelectedItems.Cast<Client>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующие {clientsForRemove.Count()} элементов?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        AdZooSalonEntities.GetContext().Clients.RemoveRange(clientsForRemove);
                        AdZooSalonEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        DGridClients.ItemsSource = AdZooSalonEntities.GetContext().Clients.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни одну запись для удаления!", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new AddEditClientPage((sender as Button).DataContext as Client));
        }
    }
}
