using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBI.Domain.Seeds
{
    public abstract class BaseEntity<T> where T : BaseAuditModel
    {
        public virtual Guid Guid { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedbyUserGuid { get; set; }
        public Guid? LastModifiedByUserGuid { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public abstract T MapToModel();
        public abstract T MapToModel(T t);
    }
}
