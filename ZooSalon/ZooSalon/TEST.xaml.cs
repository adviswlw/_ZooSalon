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

namespace ZooSalon
{
    /// <summary>
    /// Логика взаимодействия для TEST.xaml
    /// </summary>
    public partial class TEST : Window
    {
        public TEST()
        {
            InitializeComponent();
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            //frameContent.Navigate(new Home());
        }

        private void rdService_Click(object sender, RoutedEventArgs e)
        {
            //frameContent.Navigate(new Home());
        }

        private void rdProduct_Click(object sender, RoutedEventArgs e)
        {
            //frameContent.Navigate(new Home());
        }

        private void rdOrder_Click(object sender, RoutedEventArgs e)
        {
            //frameContent.Navigate(new Home());
        }

        private void rdUsers_Click(object sender, RoutedEventArgs e)
        {
            //frameContent.Navigate(new Home());
        }

        private void rdSettings_Click(object sender, RoutedEventArgs e)
        {
            //frameContent.Navigate(new Home());
        }

        //private void Themes_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Themes.IsChecked == true)
        //        ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
        //    else
        //        ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
    }
}
