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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new HistoryPage());
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new AddEditUserPage(null));
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (DGridUsers.SelectedItems.Count > 0)
            {
                var usersForRemove = DGridUsers.SelectedItems.Cast<User>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemove.Count()} элементов?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        AdZooSalonEntities.GetContext().Users.RemoveRange(usersForRemove);
                        AdZooSalonEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        DGridUsers.ItemsSource = AdZooSalonEntities.GetContext().Users.ToList();
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
            Manager.frameContent.Navigate(new AddEditUserPage((sender as Button).DataContext as User));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    AdZooSalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridUsers.ItemsSource = AdZooSalonEntities.GetContext().Users.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
