using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TECIS.Web.ViewModels
{
    public class MembersViewModel
    {
        [Key]
        [Required]
        [Display(Name = "Member Id")]
        public decimal MemberId { get; set; }
        [Required]
        [Display(Name = "Member Name")]
        public string MemberName { get; set; }
        public string MemberSchedulerColor { get; set; }
    }
}