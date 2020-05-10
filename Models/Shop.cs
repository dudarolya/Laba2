  using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class Shop
    {
        public Shop()
        {
            Workers = new List<Worker>();
            ShopTypes = new List<ShopTypes>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Adress { get; set; }

        [Phone(ErrorMessage = "Invalid phone number!")]
        public string Phone { get; set; }

        [Display(Name = "Shop area (in square metres)")]
        public int Area { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<ShopTypes> ShopTypes { get; set; }

    }
}
