using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAspCore3.Models
{
    public class SubCategory
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "SubCategory Name : ")]
        public String name { get; set; }

        
        public int category_id { get; set; }

        [ForeignKey("category_id ")]
        public virtual Category Category { get; set; }

    }
}
