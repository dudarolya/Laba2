using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FlowerShops.Models
{
    public class Gender
    {
        public Gender()
        {
            Workers = new List<Worker>();
        }
        [Key]
        public string Name { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
