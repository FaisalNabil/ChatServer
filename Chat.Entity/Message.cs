//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chat.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Message()
        {
            this.MessageReadStatus = new HashSet<MessageReadStatus>();
        }
    
        public int MessageId { get; set; }
        public string SendDate { get; set; }
        public string MessageBody { get; set; }
        public int UserUserId { get; set; }
        public int MessageThreadThreadId { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageReadStatus> MessageReadStatus { get; set; }
        public virtual MessageThread MessageThread { get; set; }
    }
}
