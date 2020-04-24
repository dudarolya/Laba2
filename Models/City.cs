using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class City
    {
        public City()
        {
            Shops = new List<Shop>();
        }

        [Key]
        public int Id;

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Name { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
