namespace ControlTienda.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class User : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50)] //Manuel Ricardo Zambrana Castaños
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(25)] //71171741;(+591)46462270
        public string Phone { get; set; }

        [ConcurrencyCheck, MinLength(6,ErrorMessage = "At less you need 6 characters." ), MaxLength(8, ErrorMessage = "You just need 8 characters." )] //[ConcurrencyCheck, MaxLength(10, ErrorMessage="BloggerName must be 10 characters or less"),MinLength(5)]
        public string Nickname { get; set; }

        [MinLength(8), MaxLength(15)]
        public string Password { get; set; }


        public Rol Rol { get; set; }
    }
}
