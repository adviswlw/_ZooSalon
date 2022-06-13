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
    /// Логика взаимодействия для AddEditOrderPage.xaml
    /// </summary>
    public partial class AddEditOrderPage : Page
    {

        private ClientService currentRecord;
        private Dictionary<int, string> comboBoxClientData = new Dictionary<int, string>();
        private Dictionary<int, string> comboBoxEmployeeData = new Dictionary<int, string>();
        private string selectedValueClient;
        private string selectedValueEmployee;

        //        вставить в столб ClientServiceView record
        public AddEditOrderPage(ClientServiceView record)
        {
            InitializeComponent();

            currentRecord = new ClientService();
            try
            {
                if (record != null)
                {
                    currentRecord = AdZooSalonEntities.GetContext().ClientServices.Select(p => p).Where(p => p.Id == record.Id).First();
                    datePickerDate.Minimum = null;
                }
                else
                    currentRecord.Date = DateTime.Now;
                DataContext = currentRecord;
            }
            catch
            {
                MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            comboBoxService.ItemsSource = AdZooSalonEntities.GetContext().Services.Where(p => p.IsActual == true).ToList();
            foreach (Client client in AdZooSalonEntities.GetContext().Clients.ToList())
            {
                comboBoxClientData.Add(client.Id, client.LastName + " " + client.FirstName.First() + ". " + (!String.IsNullOrWhiteSpace(client.Patronymic) ? client.Patronymic.First() + "." : ""));
            }
            comboBoxClient.ItemsSource = comboBoxClientData.Values;
            fillComboBoxEmployeeData(null);


            if (comboBoxClientData.TryGetValue(currentRecord.ClientId, out selectedValueClient))
            {
                comboBoxClient.SelectedItem = selectedValueClient;
            }

        }

        private void comboBoxService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxService.SelectedItem != null)
            {
                Service currentService = (Service)comboBoxService.SelectedItem;
                ServiceCategory serviceCategory = AdZooSalonEntities.GetContext().ServiceCategories.Where(c => c.ServiceId == currentService.Id).FirstOrDefault();
                Category currentCategory = AdZooSalonEntities.GetContext().Categories.Where(p => p.Id == serviceCategory.CategoryId).FirstOrDefault();
                //                         || currentCategory.Id == 2 || currentCategory.Id == 3 || currentCategory.Id == 4
                if (currentCategory.Id == 1 )
                    fillComboBoxEmployeeData("Грумер");
                else if (currentCategory.Id == 2)
                    fillComboBoxEmployeeData("Ведущий грумер");
                //else if (currentCategory.Id == 6)
                //    fillComboBoxEmployeeData("Грумер");
                if (comboBoxEmployeeData.TryGetValue(currentRecord.EmployeeId, out selectedValueEmployee))
                {
                    comboBoxEmployee.SelectedItem = selectedValueEmployee;
                }
            }
        }

        private void fillComboBoxEmployeeData(string post)
        {
            try
            {
                comboBoxEmployeeData.Clear();
                comboBoxEmployee.ItemsSource = null;
                if (post == null)
                {
                    foreach (Employee employee in AdZooSalonEntities.GetContext().Employees.ToList())
                    {
                        comboBoxEmployeeData.Add(employee.Id, employee.LastName + " " + employee.FirstName.First() + ". " + (!String.IsNullOrWhiteSpace(employee.Patronymic) ? employee.Patronymic.First() + "." : "") + ". (" + employee.Post + ")");
                    }
                }
                else
                {
                    foreach (Employee employee in AdZooSalonEntities.GetContext().Employees.Where(p => p.Post == post).ToList())
                    {
                        comboBoxEmployeeData.Add(employee.Id, employee.LastName + " " + employee.FirstName.First() + ". " + (!String.IsNullOrWhiteSpace(employee.Patronymic) ? employee.Patronymic.First() + "." : "") + ". (" + employee.Post + ")");
                    }
                }
                comboBoxEmployee.ItemsSource = comboBoxEmployeeData.Values;
            }
            catch
            {
                MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (comboBoxClient.SelectedItem == null)
            {
                stringBuilder.AppendLine("Не выбран клиент");
            }
            if (comboBoxService.SelectedItem == null)
            {
                stringBuilder.AppendLine("Не выбрана услуга");
            }
            if (comboBoxEmployee.SelectedItem == null)
            {
                stringBuilder.AppendLine("Не выбран сотрудник");
            }
            if (currentRecord.Date == null)
            {
                stringBuilder.AppendLine("Не выбрана дата");
            }
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                currentRecord.EmployeeId = comboBoxEmployeeData.FirstOrDefault(p => p.Value == comboBoxEmployee.SelectedItem.ToString()).Key;
                currentRecord.ClientId = comboBoxClientData.FirstOrDefault(p => p.Value == comboBoxClient.SelectedItem.ToString()).Key;
                currentRecord.Date = (DateTime)datePickerDate.Value;
                if (currentRecord.Id == 0)
                {
                    AdZooSalonEntities.GetContext().ClientServices.Add(currentRecord);
                }
                AdZooSalonEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.frameContent.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString());
            }
        }
    }
}
