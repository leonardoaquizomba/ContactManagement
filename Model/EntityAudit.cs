using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Model
{
    public abstract class EntityAudit : Entity
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
