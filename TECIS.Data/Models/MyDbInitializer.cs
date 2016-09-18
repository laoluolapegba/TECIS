using System.Data.Entity;

namespace TECIS.Data.Models
{
    public class MyDbInitializer : CreateDatabaseIfNotExists<TecIsEntities>
    {
        protected override void Seed(TecIsEntities context)
        {
            // create 3 students to seed the database
            //context.Students.Add(new Student { ID = 1, FirstName = "Mark", LastName = "Richards", EnrollmentDate = DateTime.Now });
            //context.Students.Add(new Student { ID = 2, FirstName = "Paula", LastName = "Allen", EnrollmentDate = DateTime.Now });
            //context.Students.Add(new Student { ID = 3, FirstName = "Tom", LastName = "Hoover", EnrollmentDate = DateTime.Now });
            //base.Seed(context);
        }
    }
}
