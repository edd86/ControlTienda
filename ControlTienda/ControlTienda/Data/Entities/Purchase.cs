namespace ControlTienda.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchase : IEntity
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        [MaxLength(250)]
        public string Remark { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public int Quantity { get; set; }


        public CashFlow CashFlow { get; set; }
    }
}
