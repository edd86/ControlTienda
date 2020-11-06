﻿namespace ControlTienda
{
    using ControlTienda.Data;
    using ControlTienda.Data.Entities;
    using ControlTienda.Encrypt;
    using ControlTienda.FrontEnd;
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
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DataContext context = new DataContext();
            UserRepository generic = new UserRepository(context);
            LoggRepository loggRepository = new LoggRepository(context);
            
            Logg logg = new Logg();
            Encrypting en = new Encrypting();
            ParentWindow ventana = new ParentWindow();

            string nick = TbUserName.Text;
            var user = generic.user(nick);

            if(!(user == null))
            {
                if (!generic.Exist(user.Id))
                    MessageBox.Show("User does not exist...", "WARNING!!!");
                else
                {
                    string pass = TbPassword.Password;
                    if (en.GetSHA256(pass) == user.Password)
                    {
                        MessageBox.Show("Logueado... " + user.Name);
                        logg.DateLogin = DateTime.Now;
                        logg.UserId = user.Id;
                        user.StatusLog = true;
                        generic.Update(user);
                        loggRepository.Create(logg);
                        ventana.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }      
                }
            }
            else
            {
                MessageBox.Show("User does not exist...", "WARNING!!!");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
