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
using ZooSalon.Themes;

namespace ZooSalon.Administration
{
    /// <summary>
    /// Логика взаимодействия для MainWinAdmin.xaml
    /// </summary>
    public partial class MainWinAdmin : Window
    {
        User currentUser; 
        //              
        public MainWinAdmin(User user)
        {
            InitializeComponent();

            //frameContent.Navigate(new mainPage());

            //Manager.frameContent = frameContent;

            currentUser = user;

            Style = (Style)FindResource(typeof(Window));

            Manager.frameContent = frameContent;
            Manager.frameContent.Navigate(new StartupPage(currentUser, this));

            txtLogin.Text = Manager.loginedUser.Login;
            try
            {
                roleImage.ImageSource = Manager.LoadImage(AdZooSalonEntities.GetContext().Roles.Where(p => p.Id == Manager.loginedUser.RoleId).Select(p => p.PhotoPath).First());
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки изображения профиля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (currentUser.Role.Name == "admin")
            {
                btnUsers.Visibility = Visibility.Visible;
                btnRecord.Visibility = Visibility.Collapsed;
                btnServices.Visibility = Visibility.Collapsed;
                btnClients.Visibility = Visibility.Collapsed;
                btnEmployeers.Visibility = Visibility.Collapsed;
                btnReports.Visibility = Visibility.Collapsed;
            }
            else if (currentUser.Role.Name == "manager")
            {
                btnUsers.Visibility = Visibility.Collapsed;
                btnRecord.Visibility = Visibility.Visible;
                btnServices.Visibility = Visibility.Visible;
                btnClients.Visibility = Visibility.Visible;
                btnEmployeers.Visibility = Visibility.Collapsed;
                btnReports.Visibility = Visibility.Collapsed;
            }
            else if (currentUser.Role.Name == "accountant")
            {
                btnUsers.Visibility = Visibility.Collapsed;
                btnRecord.Visibility = Visibility.Visible;
                btnServices.Visibility = Visibility.Visible;
                btnClients.Visibility = Visibility.Visible;
                btnEmployeers.Visibility = Visibility.Visible;
                btnReports.Visibility = Visibility.Visible;
            }

        }


        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            else
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            Hide();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new StartupPage(currentUser, this));
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePasssword = new ChangePassword(currentUser, this);
            changePasssword.ShowDialog();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            Hide();
        }
        //
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frameContent.CanGoBack)
                Manager.frameContent.GoBack();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (frameContent.CanGoForward)
                Manager.frameContent.GoBack();
        }
        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new UserPage());
        }
        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new CategoriesPage());
        }
        
        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new OrderPage());
        }
        
        private void btnServices_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new CategoriesPage());
        }
        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new ClientsPage());
        }
        private void btnEmployeers_Click(object sender, RoutedEventArgs e)
        {
            Manager.frameContent.Navigate(new EmployeersPage());
        }
        
        private void btnReports_Click(object sender, RoutedEventArgs e)
        {

            Manager.frameContent.Navigate(new ReportsPage());
        }



        #region buttonsStyles
        private void btnUsers_MouseEnter(object sender, MouseEventArgs e)
        {
            btnUsers.Foreground = Brushes.Black;
            imageUser.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/userActive.png", UriKind.Absolute));
        }

        private void btnUsers_MouseLeave(object sender, MouseEventArgs e)
        {
            btnUsers.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666"));
            imageUser.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/userInactive.png", UriKind.Absolute));
        }

        private void btnRedord_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRecord.Foreground = Brushes.Black;
            imageRecord.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/recordActive.png", UriKind.Absolute));
        }

        private void btnRedord_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRecord.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666"));
            imageRecord.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/recordInactive.png", UriKind.Absolute));
        }

        private void btnServices_MouseEnter(object sender, MouseEventArgs e)
        {
            btnServices.Foreground = Brushes.Black;
            imageService.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/barberScissorsActive.png", UriKind.Absolute));
        }

        private void btnServices_MouseLeave(object sender, MouseEventArgs e)
        {
            btnServices.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666"));
            imageService.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/barberScissorsInactive.png", UriKind.Absolute));
        }

        private void btnClients_MouseEnter(object sender, MouseEventArgs e)
        {
            btnClients.Foreground = Brushes.Black;
            imageClient.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/clientActive.png", UriKind.Absolute));
        }

        private void btnClients_MouseLeave(object sender, MouseEventArgs e)
        {
            btnClients.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666"));
            imageClient.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/clientInactive.png", UriKind.Absolute));
        }

        private void btnEmployeers_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEmployeers.Foreground = Brushes.Black;
            imageEmployee.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/employeeActive.png", UriKind.Absolute));
        }

        private void btnEmployeers_MouseLeave(object sender, MouseEventArgs e)
        {
            btnEmployeers.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666"));
            imageEmployee.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/employeeInactive.png", UriKind.Absolute));
        }

        private void btnReports_MouseEnter(object sender, MouseEventArgs e)
        {

            btnReports.Foreground = Brushes.Black;
            imageReport.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/reportActive.png", UriKind.Absolute));
        }

        private void btnReports_MouseLeave(object sender, MouseEventArgs e)
        {
            btnReports.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666"));
            imageReport.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/reportInactive.png", UriKind.Absolute));
        }

        #endregion

        private void btnRecord_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRecord.Foreground = Brushes.Black;
            imageRecord.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/recordActive.png", UriKind.Absolute));
        }

        private void btnRecord_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRecord.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666"));
            imageRecord.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/MenuImages/recordInactive.png", UriKind.Absolute));
        }
    }
    class InverseBooleanConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return !((bool)value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return !((bool)value);
            }
        }
    
}
