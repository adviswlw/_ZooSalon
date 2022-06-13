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
    /// Логика взаимодействия для CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }

        private void btnExpandServices_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new ServicePage(null));
        }

        private void ListViewCategories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Category choosenCategory = (Category)ListViewCategories.SelectedItem;
            Manager.frameContent.Navigate(new ServicePage(choosenCategory));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    AdZooSalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    ListViewCategories.ItemsSource = AdZooSalonEntities.GetContext().Categories.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка обновления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
