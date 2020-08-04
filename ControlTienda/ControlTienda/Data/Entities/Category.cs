namespace ControlTienda.Data.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    

    public class Category : IEntity
    {
        public int Id { get; set; }

        [MaxLength(30)]  //Lácteos, Fiambres, Bebidas Alcoholicas
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desciption { get; set; }
    }
}
