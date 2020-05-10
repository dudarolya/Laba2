using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class TypeOfGood
    {
        public TypeOfGood()
        {
            Goods = new List<Good>();
            ShopTypes = new List<ShopTypes>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
        public virtual ICollection<ShopTypes> ShopTypes { get; set; }
    }
}
