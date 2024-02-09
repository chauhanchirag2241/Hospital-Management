using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("department")]
    public class department : ModelBase
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public Boolean isActive { get; set; } = true;
    }
}
