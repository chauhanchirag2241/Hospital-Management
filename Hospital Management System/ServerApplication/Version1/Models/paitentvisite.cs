using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("paitentvisite")]
    public class Getpaitentvisite : ModelBase
    {

        [Key]
        public int PaitentVisiteId { get; set; }

        public int PaitentId { get; set; }

        public int AddedbyId { get; set; }

        public int AssignToId { get; set; } = 0;

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; }

        public string MedicineIds { get; set; }

        public int ReportId { get; set; }

        public string Status { get; set; }

        public bool isActive { get; set; } = true;

    }
    [Table("paitentvisite")]
    public class PaitentVisite : ModelBase
    {
        public int? PaitentId { get; set; }

        public int? AddedbyId { get; set; }

        public string? AssignToId { get; set; }

        public DateTime? Date { get; set; } = DateTime.Now;

        public string? Description { get; set; }

        public string? medicineIds { get; set; }
        public int? ReportId { get; set; }

        public string? Status { get; set; }

        public bool isActive { get; set; } = true;
    }
    public class paitentvisiteInfo
    {
        public string paitentId { get; set; }
        public string paitentName { get; set; }
        public string assignByName { get; set; }
        public string Description { get; set; }
        public string status { get; set; }

    }

    public class paitentVisiteByPaitentId
    {
        public int paitentVisiteId { get; set; }

        public int paitentId { get; set; }

        public string paitentName { get; set; }

        public string addedByName { get; set; }

        public string description { get; set; }

        public string medicineNames { get; set; }

        public string employeeCode { get; set; }

        public string qualification { get; set; }
    }

    public class medicineByPaitentId
     {
        public int paitentId { get; set; }
        public string  paitentName { get; set; }        
        public string medicineName { get; set; }
        public decimal quantity { get; set; }
        public decimal amount { get; set; }
    }

}
