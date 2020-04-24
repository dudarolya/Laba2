using System.ComponentModel.DataAnnotations;

namespace FlowerShops.Models
{
    public class Gender
    {
        [Key]
        public string Name { get; set; }
    }
}
