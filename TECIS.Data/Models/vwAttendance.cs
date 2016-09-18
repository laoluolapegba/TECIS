using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{

    [Table("vw_Attendance")]
    public class vwAttendance
    {
        [Key]
        public int Id { get; set; }
        public System.DateTime servicedate { get; set; }
        public int WeekNo { get; set; }
        public int service1 { get; set; }
        public int service2 { get; set; }
        public int service3 { get; set; }
        public int service4 { get; set; }
    }
}
