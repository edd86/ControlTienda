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
    /// Lógica de interacción para RolManager.xaml
    /// </summary>
    public partial class RolManager : Window
    {
        public RolManager()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshGrid()
        {
            Rol rol = new Rol();
            DgRols.ItemsSource = null;
            DgRols.ItemsSource = RolRepository.AllRolToList().OrderBy(r => r.Name);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Rol rol = new Rol();
            DataContext context = new DataContext();
            RolRepository rolRepository = new RolRepository(context);
            UserWindow window = new UserWindow();
            string name, details;
            name = TbName.Text;
            details = TbDetail.Text;
            if (!rolRepository.Exist(rolRepository.ObtainId(name)))
            {
                rol.Name = name;
                rol.Details = details;
                rolRepository.Create(rol);
                MessageBox.Show("Rol Created! "+name);
                window.RefreshComboBox();
                RefreshGrid();
            }
            else
                MessageBox.Show("Rol exist, change the name.");
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            UserWindow window = new UserWindow();
            window.RefreshComboBox();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            DataContext context = new DataContext();
            RolRepository rolRepository = new RolRepository(context);
            var RolDel = rolRepository.GetById(Id);
            if (!(RolDel.Name == "Manager"))
            {
                rolRepository.Delete(RolDel);
                RefreshGrid();
                MessageBox.Show("Rol "+RolDel.Name+" eliminado", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("No se puede eliminar el Rol Manager", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataContext context = new DataContext();
            RolRepository rolRepository = new RolRepository(context);

            int Id = (int)((Button)sender).CommandParameter;
            var rol = rolRepository.GetById(Id);
            if(!(rol.Name == "Manager"))
            {
                rol.Name = TbName.Text;
                rol.Details = TbDetail.Text;
                rolRepository.Update(rol);
                MessageBox.Show("Rol Actualizado", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("El Rol Manager no se puede Modificar", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefreshGrid();
        }

        private void DgRols_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var RolSelected = DgRols.SelectedItem as Rol;
            FillTextBox(RolSelected);
        }

        private void FillTextBox(Rol rolSelected)
        {
            TbName.Text = rolSelected.Name;
            TbDetail.Text = rolSelected.Details;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserWindow window = new UserWindow();
            window.RefreshComboBox();
        }
    }
}