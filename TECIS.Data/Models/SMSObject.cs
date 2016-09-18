using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TECIS.Data.Models
{
    public class SMSObject
    {
        [Key]
        [ScaffoldColumn(false)]
        public string MessageId { get; set; }
        [Required(ErrorMessage = "The SMS text must not be empty")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(160, MinimumLength = 2)]
        public string SMSText { get; set; }
        [Required(ErrorMessage = "At least 1 recipient is required")]
        [DisplayName("SMS Recipients")]
        public string msisdn { get; set; }
        public int ReturnValue { get; set; }

    }
}