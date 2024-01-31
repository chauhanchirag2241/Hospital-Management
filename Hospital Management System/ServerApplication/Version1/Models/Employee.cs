using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SG = ServerApplication.Generic;

namespace ServerApplication.Version1.Models
{
    [Table("employee")]
    public class Employee : ModelBase
    {
        [Key]
        [Column("employeeid")]
        public int EmployeeId { get; set; }

        [Column("departmentid")]
        public int DepartmentId { get; set; }

        [Column("employeetype")]
        public  int EmployeeType { get; set; }

        [Column("employeecode")]
        public int EmployeeCode { get; set; }

        [Column("employeename")]
        public string EmployeeName { get; set; }

        [Column("gender")]
        public int Gender { get; set; }

        [Column("mobileno")]
        public string MobileNo { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("qualification")]
        public string Qualification { get; set; }

        [Column("jobspecification")]
        public string JobSpecification { get; set; }

        [Column("isactive")]
        public Boolean isActive { get; set; } = true;
    }
}
