namespace ControlTienda.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CashFlow
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal MoneyIncome { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal MoneyOutflow { get; set; }


        public Cash Cash { get; set; }
    }
}
