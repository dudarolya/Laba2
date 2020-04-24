using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class Shop
    {
        public Shop()
        {
            Workers = new List<Worker>();
            TypeOfGoods = new List<TypeOfGood>();
        }

        [Key]
        public int Id { get; set; }

        [Key]
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
        public virtual ICollection<TypeOfGood> TypeOfGoods { get; set; }
    }
}
