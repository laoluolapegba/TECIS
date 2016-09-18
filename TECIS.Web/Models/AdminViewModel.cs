using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TECIS.Web.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }
        public bool EmailConfirmed { get; set; }
        [Display(Name = "Confirmed by Admin")]
        public bool AdminConfirmed { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}