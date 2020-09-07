using System.ComponentModel.DataAnnotations.Schema;

namespace OOI.Data.Entities
{
    public class CastPhoto : BaseEntity
    {
        public string ImagePath { get; set; }
        public int CastID { get; set; }
        [ForeignKey("CastID")]
        public virtual Cast Cast { get; set; }
    }
}