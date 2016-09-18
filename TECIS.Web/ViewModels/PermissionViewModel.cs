
namespace TECIS.Web.Models
{
    public class PermissionViewModel
    {
        public decimal PERMISSION_ID { get; set; }

        public string PERMISSIONDESCRIPTION { get; set; }

        public string ACTION_NAME { get; set; }

        public string CONTROLLER_NAME { get; set; }

        public int PARENT_PERMISSION { get; set; }

        public string FORM_URL { get; set; }

        public string IMAGE_URL { get; set; }
        public string ICON_CLASS { get; set; }
        public string ISOPEN_CLASS { get; set; }
        public string TOGGLE_ICON { get; set; }

        public bool ISACTIVE { get; set; }
        public bool hasChildren { get; set; }
    }
}