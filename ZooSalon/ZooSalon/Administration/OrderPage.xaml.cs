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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private decimal costOut = 0;
        private DateTime dateOut;

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Decimal.TryParse(txtBoxSearch.Text, out costOut);
            DateTime.TryParse(txtBoxSearch.Text, out dateOut);
            try
            {
                List<ClientServiceView> currentClientService = AdZooSalonEntities.GetContext().ClientServiceViews.ToList();
                currentClientService = currentClientService.Where(p => p.ClientInfo.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.EmployeeInfo.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.Service.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.Cost.Equals(costOut) || p.Date.Equals(dateOut)).ToList();
                DGridRecords.ItemsSource = currentClientService.ToList();
                if (currentClientService.Count == 0)
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

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new AddEditOrderPage(null));
        }

        private void btnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (DGridRecords.SelectedItems.Count > 0)
            {
                IEnumerable<ClientServiceView> rows = DGridRecords.SelectedItems.Cast<ClientServiceView>().ToList();
                try
                {
                    if (MessageBox.Show($"Вы точно хотите удалить следующие {rows.Count()} элементов?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            foreach (var c in rows)
                            {
                                AdZooSalonEntities.GetContext().Database.ExecuteSqlCommand("DELETE FROM ClientService WHERE ClientService.Id = " + c.Id);
                            }
                            MessageBox.Show("Данные удалены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            DGridRecords.ItemsSource = AdZooSalonEntities.GetContext().ClientServiceViews.ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Вы не выбрали ни одну запись для удаления!", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new AddEditOrderPage((sender as Button).DataContext as ClientServiceView));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    AdZooSalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridRecords.ItemsSource = AdZooSalonEntities.GetContext().ClientServiceViews.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка обновления записей!\nПопробуйте снова обновить записи", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
