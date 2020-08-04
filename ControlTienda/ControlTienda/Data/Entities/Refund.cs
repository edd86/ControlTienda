namespace ControlTienda.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Refund : IEntity
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        [MaxLength(250)]
        public string Remark { get; set; }


        public DetailSale DetailSale { get; set; }
    }
}
