using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("paitentvisite")]
    public class paitentvisite : ModelBase
    {
        [Key]
        public int PaitentVisiteId { get; set; }

        public int PaitentId { get; set; }

        public int AssignToId { get; set; }

        public string Status { get; set; }

        public bool isActive { get; set; } = true;
    }
}
