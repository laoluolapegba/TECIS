namespace TECIS.Web.Models.Scheduler
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using System;
    using System.Data;
    using TECIS.Data.Models;
    public class SchedulerTaskService : ISchedulerEventService<TaskViewModel>
    {

        private TecIsEntities db;

        public SchedulerTaskService(TecIsEntities context)
        {
            db = context;
        }

        public SchedulerTaskService()
            : this(new TecIsEntities())
        {
        }

        public virtual IQueryable<TaskViewModel> GetAll()
        {
            return db.Appointments.ToList().Select(task => new TaskViewModel
            {
                TaskID = task.Id,
                Title = task.Title,
                Start = DateTime.SpecifyKind(task.StartDate, DateTimeKind.Utc),
                End = DateTime.SpecifyKind(task.EndDate, DateTimeKind.Utc),
                //StartTimezone = task.StartTimezone,
                //EndTimezone = task.EndTimezone,
                Description = task.Description,
                IsAllDay = task.IsAllDay,
                RecurrenceRule = task.RecurrenceRule,
                RecurrenceException = task.RecurrenceException,
                RecurrenceID = task.RecurrenceID,
                OwnerID = task.OwnerID
            }).AsQueryable();  
        }

        public virtual void Insert(TaskViewModel task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {
                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "";
                }

                var entity = task.ToEntity();

                db.Appointments.Add(entity);
                db.SaveChanges();

                task.TaskID = entity.Id;
            }
        }

        public virtual void Update(TaskViewModel task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {
                if (string.IsNullOrEmpty(task.Title))
                {
                    task.Title = "";
                }

                var entity = task.ToEntity();
                db.Appointments.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public virtual void Delete(TaskViewModel task, ModelStateDictionary modelState)
        {
            var entity = task.ToEntity();
            db.Appointments.Attach(entity);

            var recurrenceExceptions = db.Appointments.Where(t => t.RecurrenceID == task.TaskID);

            foreach (var recurrenceException in recurrenceExceptions)
            {
                db.Appointments.Remove(recurrenceException);
            }

            db.Appointments.Remove(entity);
            db.SaveChanges();
        }

        //TODO: better naming or refactor
        private bool ValidateModel(TaskViewModel appointment, ModelStateDictionary modelState)
        {
            if (appointment.Start > appointment.End)
            {
                modelState.AddModelError("errors", "End date must be greater or equal to Start date.");
                return false;
            }
            
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}