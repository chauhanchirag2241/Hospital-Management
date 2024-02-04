using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    public class ModelBase
    {

        [Column("createdby")]
        public int CreatedBy { get; set; } = 1;

        [Column("cratedon")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Column("updatedby")]
        public int UpdatedBy { get; set; } = 1;

        [Column("updatedon")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

       
    }
}
