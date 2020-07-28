

namespace ControlTienda.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Logg
    {
        public int Id { get; set; }
        public DateTime? DateLogin { get; set; }
        public DateTime? DateLogout { get; set; }

        [MaxLength(250)]
        public string Remark { get; set; }


        public User User { get; set; }
    }
}
