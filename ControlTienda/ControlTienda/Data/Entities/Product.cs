

namespace ControlTienda.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Product : IEntity
    {
        public int Id { get; set; }

        [MaxLength(25)] //7774900003425
        public string BarCode { get; set; }  

        [MaxLength(150)] //Mayonesa Hellsman Gold de 500gr.
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }


        public Category Category { get; set; }

    }

    
}
