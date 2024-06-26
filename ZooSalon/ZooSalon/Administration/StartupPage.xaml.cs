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


namespace ZooSalon.Administration
{
    /// <summary>
    /// Логика взаимодействия для StartupPage.xaml
    /// </summary>
    public partial class StartupPage : Page
    {
        private User userToChange;
        private MainWinAdmin baseWindow;
        public StartupPage(User currentUser, MainWinAdmin baseWindow)
        {
            InitializeComponent();
            DataContext = currentUser;
            userToChange = currentUser;
            this.baseWindow = baseWindow;
            btnSave.IsEnabled = false;
            try
            {
                userImage.Source = Manager.LoadImage(AdZooSalonEntities.GetContext().Roles.Where(p => p.Id == Manager.loginedUser.RoleId).Select(p => p.PhotoPath).First());
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки изображения роли", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            txtBlockHello.Text += Manager.loginedUser.FirstName + " " + Manager.loginedUser.LastName;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxFirstName.IsEnabled == true)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (string.IsNullOrEmpty(userToChange.FirstName))
                {
                    stringBuilder.AppendLine("Не введено имя");
                }
                if (string.IsNullOrEmpty(userToChange.LastName))
                {
                    stringBuilder.AppendLine("Не введена фамилия");
                }
                if (string.IsNullOrEmpty(userToChange.Login))
                {
                    stringBuilder.AppendLine("Не введен логин");
                }
                if (stringBuilder.Length != 0)
                {
                    MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    AdZooSalonEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!\nДля дальнейшей работы войдите в учетную запись снова", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    Login authWindow = new Login();
                    authWindow.Show();
                    baseWindow.Close();
                    if (Manager.frameContent.CanGoBack)
                        Manager.frameContent.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Для редактирования данных нажмите 'Редактировать'", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxLogin.IsEnabled == false)
            {
                txtBoxFirstName.IsEnabled = true;
                txtBoxLastName.IsEnabled = true;
                txtBoxLogin.IsEnabled = true;
                btnSave.IsEnabled = true;
            }
            else
            {
                txtBoxFirstName.IsEnabled = false;
                txtBoxLastName.IsEnabled = false;
                txtBoxLogin.IsEnabled = false;
                btnSave.IsEnabled = false;
            }
        }
    }
}
