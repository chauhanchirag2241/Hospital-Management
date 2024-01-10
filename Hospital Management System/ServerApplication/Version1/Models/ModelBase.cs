using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApplication.Version1.Models
{
    public class ModelBase
    {
       
        [Column("createdby")]
        public int CreatedBy { get; set; }

        [Column("cratedon")]
        public DateTime CreatedOn { get; set; }

        [Column("updatedby")]
        public int UpdatedBy { get; set; }

        [Column("updatedon")]
        public DateTime UpdatedOn { get; set; }

       
    }
}
