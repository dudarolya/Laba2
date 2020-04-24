using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int ShopId { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Position { get; set; }

        [Phone(ErrorMessage = "Invalid phone number!")]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
