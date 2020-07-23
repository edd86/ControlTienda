namespace ControlTienda.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Rol
    {
        public int Id { get; set; }

        [MaxLength(25)] //Administrador, Encargado de TI
        public string Name { get; set; }

        [MaxLength(250)]
        public string Details { get; set; }
    }
}
