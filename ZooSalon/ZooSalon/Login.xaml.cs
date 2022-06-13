using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ZooSalon.Administration;

namespace ZooSalon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private int countErrorAuths = 0;

        public Login()
        {
            InitializeComponent();

            Style = (Style)FindResource(typeof(Window));
            DataObject.AddCopyingHandler(txtBoxPassword, this.OnCancelCommand);

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    Application.Current.MainWindow.Top = 3;
                }
                this.DragMove();
            }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool loginStatus = false;
                AuthHistory loginHistory = new AuthHistory();
                User currentUser = null;
                if (AdZooSalonEntities.GetContext().Users.Where(p => p.Login == txtBoxLogin.Text).Count() != 0)
                {
                    currentUser = AdZooSalonEntities.GetContext().Users.Where(p => p.Login == txtBoxLogin.Text).First();
                    var result = AdZooSalonEntities.GetContext().Users.ToList().Select(p => p).Where(p => p.Login == txtBoxLogin.Text && (p.Password == txtBoxPassword.Text || p.Password == txtBoxPassword.Text));
                    if (result.Count() != 0)
                    {
                        currentUser.Lastenter = DateTime.Now;
                        AdZooSalonEntities.GetContext().SaveChanges();
                        Manager.loginedUser = currentUser;
                        loginStatus = true;
                        MessageBox.Show("Вы успешно авторизовались", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWinAdmin baseWindow = new MainWinAdmin(currentUser);
                        baseWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        countErrorAuths++;
                        MessageBox.Show("Неверный пароль!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Warning);
                        if (countErrorAuths == 3)
                        {
                            countErrorAuths = 0;
                            MessageBox.Show("Превышено количество попыток входа!\nПовторите попытку через 10 секунд.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                            Thread.Sleep(10000);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (currentUser != null)
                {
                    loginHistory.DateTime = DateTime.Now;
                    loginHistory.Status = loginStatus;
                    loginHistory.UserId = currentUser.Id;
                    AdZooSalonEntities.GetContext().AuthHistories.Add(loginHistory);
                    AdZooSalonEntities.GetContext().SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка связи с базой данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //MainWinAdmin adminW = new MainWinAdmin();
            //adminW.Show();
            //Hide();
        }

        private void registrationB_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Hide();
        }
        private void OnCancelCommand(object sender, DataObjectEventArgs e)
        {
            e.CancelCommand();
        }

        private void checkBoxShowPass_Checked(object sender, RoutedEventArgs e)
        {
            txtBoxPassword.FontFamily = new FontFamily("Roboto Light");
        }
        private void checkBoxShowPass_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBoxPassword.FontFamily = new FontFamily("Password");
        }
    }
}
