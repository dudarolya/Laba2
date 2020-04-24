using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class TypeOfGood
    {
        public TypeOfGood()
        {
            Goods = new List<Good>();
        }

        [Key]
        public int Id;

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
