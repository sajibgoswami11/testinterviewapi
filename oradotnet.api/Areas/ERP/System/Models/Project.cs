using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oradotnet.api.Areas.ERP.System.Models
{
    public class Project
    {
        [Key]  // This attribute specifies ProjectId as the primary key
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        // Other properties...

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string Details { get; set; }

        public Category Category { get; set; }

    }
}
