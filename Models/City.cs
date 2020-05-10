using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Name { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }

        public City()
        {
            Shops = new List<Shop>();
        }
    }
}
