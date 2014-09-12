using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
        public virtual bool IsUnknown { get { return false; } }
    }
}