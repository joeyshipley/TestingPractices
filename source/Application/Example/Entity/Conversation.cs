using System.ComponentModel.DataAnnotations;
using Application.Infrastructure;

namespace Application.Example.Entity
{
    public class Conversation : BaseEntity
    {
        [Required]
        // NOTE: EF saves as int, NH saves as string.
        public virtual Rules.Being Source { get; set; }
        [Required]
        [MaxLength(200)]
        public virtual string Message { get; set; }
    }

    public class UnknownConversation : Conversation
    {
        public override bool IsUnknown
        {
            get { return true; }
        }
    }
}