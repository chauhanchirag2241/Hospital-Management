using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    [Table("serveruser")]
    public class ServerUser : ModelBase
    {
        [Key]
        public int ServerUserId { get; set; }

        public int ServerRoleId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string MobileNo { get; set; }

        public string Email { get; set; }
        public Boolean isActive { get; set; }

    }
}
