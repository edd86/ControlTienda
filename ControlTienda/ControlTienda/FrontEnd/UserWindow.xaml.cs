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
        int IdDG;
        public UserWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
            RefreshComboBox();
        }

        private void BtnAddRol_Click(object sender, RoutedEventArgs e)
        {
            RolManager rolManager = new RolManager();
            rolManager.Show();
        }

        private void RefreshDataGrid()
        {
            DgUsers.ItemsSource = null;
            DgUsers.ItemsSource = UserRepository.UserToList().OrderBy(u => u.Name);
        }

        public void RefreshComboBox()
        {
            CbRol.ItemsSource = null;
            CbRol.ItemsSource = RolRepository.AllRolToList().OrderBy(r => r.Name);
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
                user.RolId = Convert.ToInt16(CbRol.SelectedValue);
                repository.Create(user);
                MessageBox.Show("User Created. " + user.Name);
                RefreshDataGrid();
            }
            else
                MessageBox.Show("The User Nick exist, change it please."); 
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            DataContext context = new DataContext();
            UserRepository userRepository = new UserRepository(context);

            var UserDel = userRepository.GetById(Id);
            userRepository.Delete(UserDel);
            RefreshDataGrid();
        }

        private void DgUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var UserSelected = DgUsers.SelectedItem as User;
            FillTextBox(UserSelected); IdDG = UserSelected.Id;
        }

        private bool ValidateId(int IdDG , int IdCP)
        {
            if (IdDG == IdCP)
                return true;
            else
                return false;
        }

        private void FillTextBox(User user)
        {
            TbName.Text = user.Name; TbAddress.Text = user.Address;
            TbPhone.Text = user.Phone; TbNickName.Text = user.Nickname;
            TbPassword.Password = user.Password; CbRol.SelectedValue = user.RolId;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataContext context = new DataContext();
            UserRepository userRepository = new UserRepository(context);
            Encrypting encrypting = new Encrypting();

            int Id = (int)((Button)sender).CommandParameter;

            if (ValidateId(IdDG, Id))
            {
                var user = userRepository.GetById(Id);
                user.Name = TbName.Text;
                user.Address = TbAddress.Text;
                user.Phone = TbPhone.Text;
                user.Nickname = TbNickName.Text;
                user.Password = encrypting.GetSHA256(TbPassword.Password);
                user.RolId = Convert.ToInt16(CbRol.SelectedValue);
                userRepository.Update(user);

                MessageBox.Show(string.Format("Name: {1}{0}Address: {2}{0}Phone: {3}{0}NickName: {4}{0}", 
                    Environment.NewLine, user.Name, user.Address, user.Phone, user.Nickname), "User Updated.");
                RefreshDataGrid();
            }
            else
                MessageBox.Show("The selected user is diferent from the button", "ERROR");
            
        }

        private void Cargar_Main(object sender, RoutedEventArgs e)
        {
            DataContext context = new DataContext();
            UserRepository userRepository = new UserRepository(context);
            RolRepository rolRepository = new RolRepository(context);
            var user = userRepository.userLog();
            if (!(user.RolId == rolRepository.ObtainId("Manager")))
            {
                BtnAddRol.IsEnabled = false;
            }
        }
    }
}