
namespace TECIS.Data.ViewModels
{
    public class AttendanceRptViewModel
    {
        public int servicedate { get; set; }
        public int WeekNo { get; set; }
        public int? TotalAttendance { get; set; }
        //public string ServiceName { get; set; }

    }
    public class WeekSparkViewModel
    {
        public int WeekNo { get; set; }
        public int ItemCount { get; set; }
        //public string ServiceName { get; set; }

    }
    public class GenderPieViewModel
    {
        public string gender { get; set; }
        public int pct { get; set; }
        //public string ServiceName { get; set; }

    }
    public class AgegroupPieViewModel
    {
        public string agegroup { get; set; }
        public int cnt { get; set; }

    }
    public class ClusterPieViewModel
    {
        public string clustername { get; set; }
        public int pct { get; set; }

    }
    public class ServiceUnitPieViewModel
    {
        public string unitname { get; set; }
        public int pct { get; set; }

    }
}
