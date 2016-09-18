using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("attendance")]
    public partial class AttendanceReg
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Service Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required")]
        public DateTime servicedate { get; set; }
        [DisplayName("Service")]
        public int? servicetype { get; set; }

        public int? location { get; set; }
        [DisplayName("Men")]
        public int? malecount { get; set; }
        [DisplayName("Women")]
        public int? femalecount { get; set; }
        [DisplayName("Babies/Children")]
        public int? childcount { get; set; }
        [DisplayName("Guests")]
        public int? guestcount { get; set; }
        [DisplayName("Converts")]
        public int? convertcount { get; set; }
        [DisplayName("Boys")]
        public int? childboyscount { get; set; }
        [DisplayName("Girls")]
        public int? childgirlscount { get; set; }
        [DisplayName("Nannies")]
        public int? childnannies { get; set; }
        [DisplayName("Teachers")]
        public int? childteachers { get; set; }
        [DisplayName("Boys")]
        public int? pteenboys { get; set; }
        [DisplayName("Girls")]
        public int? pteengirls { get; set; }
        [DisplayName("Teachers")]
        public int? pteenteachers { get; set; }
        [DisplayName("Boys")]
        public int? teenboys { get; set; }
        [DisplayName("Girls")]
        public int? teengirls { get; set; }
        [DisplayName("Teachers")]
        public int? teenteachers { get; set; }
        [DisplayName("Cars Parked")]
        public int? carscount { get; set; }
        [DisplayName("Security on duty")]
        public int? security { get; set; }
        [DisplayName("Service Started")]
        public string service_start_time { get; set; }
        [DisplayName("Service Ended")]
        public string service_end_time { get; set; }
        [Required(ErrorMessage = "Message title is required")]
        [DisplayName("Message Title")]
        public string message_title { get; set; }
        [Required(ErrorMessage = "Speaker is required")]
        [DisplayName("Speaker")]
        public string speaker { get; set; }

        public virtual ServicesType svctypes { get; set; }
        public virtual Location locations { get; set; }
    }
}
