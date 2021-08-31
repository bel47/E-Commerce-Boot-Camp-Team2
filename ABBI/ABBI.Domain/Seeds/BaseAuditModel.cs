using System;

namespace ABBI.Domain.Seeds
{
    public abstract class BaseAuditModel
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUser { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
