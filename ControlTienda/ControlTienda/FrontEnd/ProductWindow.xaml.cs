namespace ControlTienda.FrontEnd
{
    using ControlTienda.Data;
    using ControlTienda.Data.Entities;
    using ControlTienda.Query;
    using ControlTienda.Validations;
    using System;
    using System.Linq;
    using System.Windows;
    /// <summary>
    /// Lógica de interacción para ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        Product productSelected = null;

        public ProductWindow()
        {
            InitializeComponent();
            LlenarCombo();
            LlenarGrid();
        }

        private void LlenarGrid()
        {
            dgProductos.ItemsSource = null;
            dgProductos.ItemsSource = ProductDataGrid.DataGridProduct().OrderBy(p => p.Name);
        }

        private void LlenarCombo()
        {
            cbCategory.ItemsSource = null;
            cbCategory.ItemsSource = CategoryRepository.AllCategoryToList().OrderBy(c => c.Name);
            cbCategory.SelectedValuePath = "Id";
            cbCategory.DisplayMemberPath = "Name";
        }

        private void chbCategoria_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void chbCategoria_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chbCategoria.IsChecked)
            {
                gbCategoria.IsEnabled = true;
            }
            else
            {
                gbCategoria.IsEnabled = false;
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            DataContext context = new DataContext();
            ProductRepository productRepository = new ProductRepository(context);

            product.BarCode = tbBarCode.Text;
            product.CategoryId = Convert.ToInt32(cbCategory.SelectedValue);
            product.Name = tbName.Text;
            product.Price = decimal.Parse(tbPrecio.Text);
            product.Stock = int.Parse(tbStock.Text);
            productRepository.Create(product);

            LlenarGrid();
        }

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            DataContext context = new DataContext();
            CategoryRepository categoryRepository = new CategoryRepository(context);

            category.Name = tbCategoria.Text;
            categoryRepository.Create(category);

            MessageBox.Show("Categoria " + category.Name + " agregada.");
            tbCategoria.Text = null;
            LlenarCombo();
        }

        private void btnBuscarStock_Click(object sender, RoutedEventArgs e)
        {
            string dato = tbBuscarStock.Text;
            dgProductos.ItemsSource = null;
            dgProductos.ItemsSource = Busqueda.BuscarStock(dato);
        }

        private void btnLimpiarStock_Click(object sender, RoutedEventArgs e)
        {
            LlenarGrid();
            tbBuscarStock.Text = null;
            tbBuscarCompra.Text = null;
        }

        private void dgProductos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            DataContext context = new DataContext();
            ProductRepository productRepository = new ProductRepository(context);

            productSelected  = productRepository.GetById((dgProductos.SelectedItem as Product).Id);
            MessageBox.Show(productSelected.Name + " seleccionado.");
        }

        private void btnCantidadStock_Click(object sender, RoutedEventArgs e)
        {
            int cant = int.Parse(tbCantidad.Text);

            DataContext context = new DataContext();
            ProductRepository productRepository = new ProductRepository(context);

            if (productSelected != null)
            {
                productSelected.Stock = productSelected.Stock + cant;
                productRepository.Update(productSelected);
                tbCantidad.Text = null;
                MessageBox.Show("Cantidad actualizada.");
                LlenarGrid();
                productSelected = null;
            }
            else
                MessageBox.Show("No se selecciono ningun Producto", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            if(!(tbCantidad.Text == "" || int.Parse(tbCantidad.Text) == 0))
            {
                tbCantidad.Text = Convert.ToString(Convert.ToInt16(tbCantidad.Text) + 1);
            }
            else
                tbCantidad.Text = "1";
        }

        private void btnDisminuir_Click(object sender, RoutedEventArgs e)
        {
            if (!(tbCantidad.Text == "" || int.Parse(tbCantidad.Text) == 0))
            {
                tbCantidad.Text = Convert.ToString(Convert.ToInt16(tbCantidad.Text) - 1);
            }
            else
                tbCantidad.Text = "-1";
        }

        private void btnBuscarCompra_Click(object sender, RoutedEventArgs e)
        {
            string dato = tbBuscarCompra.Text;
            dgProductos.ItemsSource = null;
            dgProductos.ItemsSource = Busqueda.BuscarStock(dato);
        }
    }
}
