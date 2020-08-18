using ControlTienda.Data;
using ControlTienda.Data.Entities;
using ControlTienda.Encrypt;
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
    /// Lógica de interacción para UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
            RefreshComboBox();
        }

        private void BtnAddRol_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            DgUsers.ItemsSource = null;
            DgUsers.ItemsSource = UserRepository.UserToList();
        }

        private void RefreshComboBox()
        {
            CbRol.ItemsSource = RolRepository.AllRolToList();
            CbRol.SelectedValuePath = "Id";
            CbRol.DisplayMemberPath = "Name"; 
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Añadir Usuario
            string name, address, phone, nickname, password;
            User user = new User(); Rol rol = new Rol();
            Encrypting encrypting = new Encrypting();
            DataContext context = new DataContext();
            UserRepository repository = new UserRepository(context);
            
            name = TbName.Text;
            address = TbAddress.Text;
            phone = TbPhone.Text;
            nickname = TbNickName.Text;
            password = TbPassword.Password;

            int id = (from u in context.Users
                      where u.Nickname == nickname
                      select u.Id).FirstOrDefault();

            if (!repository.Exist(id))
            {
                user.Name = name;
                user.Address = address;
                user.Phone = phone;
                user.Nickname = nickname;
                user.Password = encrypting.GetSHA256(password);
                user.RolId = Convert.ToInt32(CbRol.SelectedValue);
                repository.Create(user);
                MessageBox.Show("User Created.");
                RefreshDataGrid();
            }
            else
                MessageBox.Show("The User Nick exist, change it please."); 
        }
    }
}