using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Category currentCategory;
        private Service currentService;
        private ServiceCategory currentServiceCategory;

        public AddEditServicePage(ServiceCategory serviceCategory, Category category)
        {
            InitializeComponent();

            try
            {
                currentService = new Service();
                if (category.Name != null)
                {
                    currentCategory = category;
                }
                else
                {
                    comboBoxCategory.Visibility = Visibility.Visible;
                    txtBlockCategory.Visibility = Visibility.Visible;
                    comboBoxCategory.ItemsSource = AdZooSalonEntities.GetContext().Categories.ToList();
                }
                currentServiceCategory = new ServiceCategory();
                string[] actuality = { "Актуальна", "Не актуальна" };
                if (serviceCategory != null)
                {
                    currentServiceCategory = serviceCategory;
                    currentService.Id = serviceCategory.ServiceId;
                    currentService = AdZooSalonEntities.GetContext().Services.Where(p => p.Id == currentService.Id).First();
                    if (currentService.IsActual == true)
                        comboBoxIsActual.SelectedItem = actuality[0];
                    else
                        comboBoxIsActual.SelectedItem = actuality[1];
                }
                DataContext = currentService;
                comboBoxIsActual.ItemsSource = actuality;

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(currentService.Name))
            {
                stringBuilder.AppendLine("Не введено название услуги");
            }
            if (string.IsNullOrWhiteSpace(currentService.Cost.ToString()) || currentService.Cost == 0)
            {
                stringBuilder.AppendLine("Не введена стоимость");
            }
            if (comboBoxIsActual.SelectedItem == null)
            {
                stringBuilder.AppendLine("Не выбрана актуальность");
            }
            if (comboBoxCategory.SelectedItem == null && currentCategory == null)
            {
                stringBuilder.AppendLine("Не выбрана категория");
            }
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                if (comboBoxIsActual.SelectedIndex == 0)
                    currentService.IsActual = true;
                else
                    currentService.IsActual = false;
                if (currentCategory == null)
                    currentServiceCategory.Category = (Category)comboBoxCategory.SelectedItem;
                else
                    currentServiceCategory.CategoryId = currentCategory.Id;
                if (currentService.Id == 0)
                {
                    AdZooSalonEntities.GetContext().Services.Add(currentService);
                    AdZooSalonEntities.GetContext().SaveChanges();
                    currentServiceCategory.ServiceId = AdZooSalonEntities.GetContext().Services.Max(p => p.Id);
                    AdZooSalonEntities.GetContext().ServiceCategories.Add(currentServiceCategory);
                }
                else
                {
                    currentServiceCategory.ServiceId = currentService.Id;
                }

                AdZooSalonEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.frameContent.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка\n" + ex.Message.ToString());
            }
        }

        private void txtBoxCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);  
        }
    }
}
