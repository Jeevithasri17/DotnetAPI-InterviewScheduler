using InterviewSchedulerAPI.InterviewSchedulerModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSchedulerAPI.DataLayer
{
    public class JobDataLayer
    {
        private readonly InterviewSchedulerDBContext db = new InterviewSchedulerDBContext();


        //public List<Job> GetAllJobs()
        //{

        //    Job isDeleted = (from i in db.Jobs
        //                     where i.RecStatus == "A"
        //                     select i).FirstOrDefault();

        //    if (isDeleted != null)
        //    {
        //        return db.Jobs.ToList();

        //    }
        //    return null;

        //}

        public List<Job> GetAllJobs()
        {

            return db.Jobs.ToList();

        }

        public int AddJob(Job a)
        {
            db.Jobs.Add(a);

            return db.SaveChanges();
        }

        public int UpdateJob(int id, Job c)
        {
            using (var db = new InterviewSchedulerDBContext())
            {
                db.Entry(c).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        public int DeleteJob(int id)
        {

            Job job = GetJobById(id);
            db.Jobs.Remove(job);
            return db.SaveChanges();


        }


        public Job GetJobById(int id)
        {
            Job c = db.Jobs.Find(id);
            return c;
        }

        public Job GetJobIdByID(string Jobid)
        {
            Job item = db.Jobs.FirstOrDefault(usr => usr.JobId == Jobid);

            return item;
        }
    }
}
