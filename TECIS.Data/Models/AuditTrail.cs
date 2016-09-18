using System;


namespace TECIS.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AuditTrail")]
    public partial class Audit
    {
        public Audit()
        {
        }
        //A new SessionId that will be used to link an entire users "Session" of Audit Logs
        //together to help identifer patterns involving erratic behavior
        [Key]
        public int AuditId { get; set; }
        public string SessionId { get; set; }
        public string IpAddress { get; set; }
        public string UserId { get; set; }
        public string UrlAccessed { get; set; }
        public DateTime TimeAccessed { get; set; }
        //A new Data property that is going to store JSON string objects that will later be able to
        //be deserialized into objects if necessary to view details about a Request
        public string AuditData { get; set; }
        public string AuditAction { get; set; }
        public string SerializedData { get; set; }


    }


}