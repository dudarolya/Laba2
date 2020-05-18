using System;
using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class Good
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public int TypeofGoodId { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Retail Price")]
        public int RetailPrice { get; set; }

        [Required(ErrorMessage = "This field can't be empty!")]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Wholesale price")]
        public int WholesalePrice { get; set; }

        /*[Required(ErrorMessage = "This field can't be empty!")]
        [Display(Name = "Amount of good")]
        public int Amount { get; set; }*/

        public virtual TypeOfGood TypeOfGood { get; set; }
    }
}
