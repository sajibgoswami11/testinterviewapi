using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oradotnet.api.Areas.ERP.System.Models
{
    public class Category
    {
        [Key]  // This attribute specifies CategoryId as the primary key
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        // Other properties...
        public List<Project> Projects { get; set; }
    }
}
