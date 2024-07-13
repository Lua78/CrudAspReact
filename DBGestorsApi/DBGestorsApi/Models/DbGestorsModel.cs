using System.ComponentModel.DataAnnotations;

namespace DBGestorsApi.Models
{
    public class DbGestorsModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string release { get; set; }

        [Required]
        public string dev_company { get; set; }
    }
}
