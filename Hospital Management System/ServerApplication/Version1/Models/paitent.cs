using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("paitent")]
    public class paitent : ModelBase
    {
        [Key]
        public int PaitentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string  MobileNo { get; set; }

        public string EmergencyContectNo { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string  BloodGroup { get; set; }

        public string MedicalIssue { get; set; }

        public int DoctorId { get; set; }

        public DateTime VisiteDate { get; set; }

        public string TimeingShift { get; set; }

        public Boolean IsActive { get; set; } = true;
    }
}
