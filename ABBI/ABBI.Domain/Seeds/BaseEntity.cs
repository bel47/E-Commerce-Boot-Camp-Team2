using System;

namespace ABBI.Domain.Seeds
{
    public abstract class BaseEntity<T> where T : BaseAuditModel
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public BaseEntity()
        {
        }
        public BaseEntity(T auditModel)
        {
            Id = auditModel.Id;
            IsActive = auditModel.IsActive;
            CreatedDate = auditModel.CreatedDate;
        }
        public abstract T MapToModel();
        public abstract T MapToModel(T t);
    }
}
