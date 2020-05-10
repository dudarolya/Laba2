using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class ShopTypes
    {
        [Key]
        public int Id { get; set; }

        public int ShopId { get; set; }

        public int TypesId { get; set; }

        public virtual Shop Shops { get; set; }

        public virtual TypeOfGood Types { get; set; }
    }
}
