using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("serveruser")]
    public class Account : ModelBase
    {
        [Key]
        public int ServerUserId { get; set; }

        [Column("serverroleid")]
        public int ServerRoleId { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("mobileno")]
        public string MobileNo { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("isactive")]
        public bool isActive { get; set; }

    }
}
