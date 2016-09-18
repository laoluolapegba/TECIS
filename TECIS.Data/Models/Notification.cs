namespace TECIS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Notification")]
    public class Notification
    {
        //    public int NotificationId { get; set; }
        //    public string Title { get; set; }
        //    public NotificationType NotificationType { get; set; }
        //    public string Controller { get; set; }
        //    public string Action { get; set; }
        //    public string UserId { get; set; }
        //    public bool IsDismissed { get; set; }


        [Key]
        public int NoteId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int NotificationType { get; set; }
        [Required]
        [StringLength(30)]
        public string Controller { get; set; }
        [Required]
        [StringLength(30)]
        public string Action { get; set; }
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }
        public bool IsDismissed { get; set; }
        public DateTime NoteDate { get; set; }
        public string SenderId { get; set; }
        public string MsgBody { get; set; }
        public int Notebadge { get; set; }
        public int priority { get; set; }
    }
    public enum NotificationType
    {
        General = 1,
        Inbox = 2
    }
    public enum NotificationBadge
    {
        Orders = 1,
        Authorisation = 2,
        UserMgmt = 3,
        CashLevel = 4
    }
}