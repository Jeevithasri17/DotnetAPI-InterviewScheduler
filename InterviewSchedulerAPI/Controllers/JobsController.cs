﻿using InterviewSchedulerAPI.DataLayer;
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
    public class JobsController : ControllerBase
    {

        private readonly JobDataLayer db = new JobDataLayer();



        [HttpGet("GetAllJobs")]

        public List<Job> GetAllJobs()
        {
            return db.GetAllJobs();
        }

        [HttpPost("AddJob")]

        public int AddJob(Job a)
        {

            return db.AddJob(a);
        }


        [HttpPut("UpdateJob")]

        public int UpdateJob(int id, Job c)
        {
            return db.UpdateJob(id, c);
        }


        [HttpDelete("DeleteJob")]

        public int DeleteJob(int id)
        {
            return db.DeleteJob(id);
        }




        [HttpGet("GetJobById/{id}")]


        public Job GetJobById(int id)
        {

            return db.GetJobById(id);

        }

        [HttpGet("Jobid/{Jobid}")]
        public IActionResult GetJobIdById(string Jobid)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var job = db.GetJobIdByID(Jobid);


            if (job == null)
            {
                return NotFound();
            }


            return Ok(job);
        }
    }
}
