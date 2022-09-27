using InterviewSchedulerAPI.InterviewSchedulerModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSchedulerAPI.DataLayer
{
    public class ScheduleDataLayer
    {
        private readonly InterviewSchedulerDBContext db = new InterviewSchedulerDBContext();

        public List<Schedule> GetAllSchedules()
        {
            return db.Schedules.Include(t => t.Job)
                            .Include(t => t.Level)
                            .Include(t => t.Candidate)
                            .Include(t => t.Panel)
                            .ToList();
        }

        public int AddSchedule(Schedule a)
        {
            db.Schedules.Add(a);

            return db.SaveChanges();
        }

        public int UpdateSchedule(int id, Schedule c)
        {
            using (var db = new InterviewSchedulerDBContext())
            {
                db.Entry(c).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        public int DeleteSchedule(int id)
        {
            Schedule b = GetScheduleById(id);
            db.Schedules.Remove(b);
            return db.SaveChanges();
        }


        public Schedule GetScheduleById(int id)
        {
            Schedule c = db.Schedules.Find(id);
            return c;
        }


       
    }
}
