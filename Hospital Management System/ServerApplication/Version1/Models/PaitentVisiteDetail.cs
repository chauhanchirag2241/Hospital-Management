using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("paitentvisitedetail")]
    public class PaitentVisiteDetail : ModelBase
    {
        [Key]
        public int PaitentVisiteDetailId { get; set; }

        public int PaitentVisiteId { get; set; }

        public int AddedbyId { get; set; }

        public DateTime Date { get; set; }

        public int ReportId { get; set; }

        public string Discription { get; set; }

        public string MedicineId { get; set; }
        public Boolean isActive { get; set; } = true;
    }
}
