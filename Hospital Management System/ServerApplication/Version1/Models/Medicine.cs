using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("medicine")]
    public class Medicine : ModelBase
    {
        [Key]
        public int MedicineId { get; set; }

        public string MedicineName { get; set; }

        public Decimal Amount { get; set; }

        public int MedicineCount { get; set; }

        public string Discription { get; set; }

        public Boolean IsActive { get; set; }

    }

    public class MedicalDepartment
    {
        public int PaitentVisiteId { get; set; }

        public int PaitentId { get; set; }
        public string PaitentName { get; set; }
        public string email { get; set; }
        public string mobileNo { get; set; }
        public int AddedById { get; set; }

        public string AddedByName { get; set; }

        public string MedicineIds { get; set; }

        public string Status { get; set; }

        public string MedicineNames { get; set; }
    }

    public class medicineBill : ModelBase
    {
        [Key]
        public int BillId { get; set; }

        public int paitentVisiteId { get; set; }

        public int paitentId { get; set; }

        public int medicineId { get; set; }

        public string medicineName { get; set; }

        public decimal quantity { get; set; }

        public decimal amount { get; set; }

    }
}
