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
    public class PanelController : ControllerBase
    {
        private readonly PanelDataLayer db = new PanelDataLayer();

        [HttpGet("GetAllPanels")]

        public List<Panel> GetAllPanels()
        {
            return db.GetAllPanels();
        }

        [HttpPost("AddPanel")]

        public int AddPanel(Panel a)
        {

            return db.AddPanel(a);
        }


        [HttpPut("UpdatePanel/{id}")]

        public int UpdatePanel(int id, Panel c)
        {
            return db.UpdatePanel(id, c);
        }


        [HttpDelete("DeletePanel")]

        public int DeletePanel(int id)
        {
            return db.DeletePanel(id);
        }

        [HttpGet("GetPanelById/{id}")]

        public Panel GetPanelById(int id)
        {
            return db.GetPanelById(id);
        }

        [HttpGet("GetAllPanelAvailabilities")]
        public List<PanelAvailability> GetAllPanelAvailabilities()
        {
            return db.GetAllPanelAvailabilities();
        }

        [HttpPost("AddPanelAvailability")]
        public int AddPanelAvailability(PanelAvailability a)
        {

            return db.AddPanelAvailability(a);
        }

        [HttpPut("UpdatePanelAvailability")]
        public int UpdatePanelAvailability(int id, PanelAvailability c)
        {
            return db.UpdatePanelAvailability(id, c);
        }

        [HttpDelete("DeletePanelAvailability")]
        public int DeletePanelAvailability(int id)
        {
            return db.DeletePanelAvailability(id);
        }

        [HttpGet("GetPanelAvailabilityById")]
        public PanelAvailability GetPanelAvailabilityById(int id)
        {
            return db.GetPanelAvailabilityById(id);
        }
    }
}
