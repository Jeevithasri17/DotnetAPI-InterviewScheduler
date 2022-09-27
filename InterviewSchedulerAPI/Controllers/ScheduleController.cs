using InterviewSchedulerAPI.DataLayer;
using InterviewSchedulerAPI.InterviewSchedulerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleDataLayer db = new ScheduleDataLayer();

        [HttpGet("GetAllSchedules")]

        public List<Schedule> GetAllSchedules()
        {
            return db.GetAllSchedules();
        }

        [HttpPost("AddSchedule")]

        public int AddSchedule(Schedule a)
        {

            return db.AddSchedule(a);
        }


        [HttpPut("UpdateSchedule/{id}")]

        public int UpdateSchedule(int id, Schedule c)
        {
            return db.UpdateSchedule(id, c);
        }


        [HttpDelete("DeleteSchedule")]

        public int DeleteSchedule(int id)
        {
            return db.DeleteSchedule(id);
        }

        [HttpGet("GetScheduleById/{id}")]

        public Schedule GetScheduleById(int id)
        {
            return db.GetScheduleById(id);
        }
    }
}
