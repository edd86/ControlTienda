using ControlTienda.Data;
using ControlTienda.Data.Entities;
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

namespace ControlTienda.FrontEnd
{
    /// <summary>
    /// Lógica de interacción para ParentWindow.xaml
    /// </summary>
    public partial class ParentWindow : Window
    {
        public ParentWindow()
        {
            InitializeComponent();
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            UserWindow window = new UserWindow();
            window.Show();
        }

        private void BtnSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow vLogin = new MainWindow();
            closeSesion();
            vLogin.Show();
            Close();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            closeSesion();
            Close();
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            DataContext context = new DataContext();
            UserRepository userRepository = new UserRepository(context);
            RolRepository rolRepository = new RolRepository(context);
            var usLogued = userRepository.userLog();
            userLoged.Content = usLogued.Nickname;
            if (!(usLogued.RolId == rolRepository.ObtainId("Manager")))
            {
                BtnUsers.IsEnabled = false;
                BtnProducts.IsEnabled = false;
            }
        }

        private void closeSesion()
        {
            DataContext context = new DataContext();
            LoggRepository loggRepository = new LoggRepository(context);
            UserRepository userRepository = new UserRepository(context);
            var userLogged = userRepository.userLog();
            var logged = loggRepository.GetAll().Last();
            userLogged.StatusLog = false;
            logged.DateLogout = DateTime.Now;
            loggRepository.Update(logged);
            userRepository.Update(userLogged);
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow();
            window.Show();
        }
    }
}
