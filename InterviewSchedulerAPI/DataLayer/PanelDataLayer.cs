using InterviewSchedulerAPI.InterviewSchedulerModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSchedulerAPI.DataLayer
{
    public class PanelDataLayer
    {

        private readonly InterviewSchedulerDBContext db = new InterviewSchedulerDBContext();

        public List<Panel> GetAllPanels()
        {
            return db.Panels.Include(t => t.Job)
                            .Include(t => t.Level)
                            .ToList();
        }

        public int AddPanel(Panel a)
        {
            db.Panels.Add(a);

            return db.SaveChanges();
        }

        public int UpdatePanel(int id, Panel c)
        {
            using (var db = new InterviewSchedulerDBContext())
            {
                db.Entry(c).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        public int DeletePanel(int id)
        {
            Panel b = GetPanelById(id);
            db.Panels.Remove(b);
            return db.SaveChanges();
        }


        public Panel GetPanelById(int id)
        {
            Panel c = db.Panels.Find(id);
            return c;
        }
    }
}
