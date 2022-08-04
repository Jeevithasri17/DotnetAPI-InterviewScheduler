using InterviewSchedulerAPI.DataLayer;
using InterviewSchedulerAPI.InterviewSchedulerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace InterviewSchedulerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class UsersController : ControllerBase
    {
      

        private readonly UsersDataLayer db = new UsersDataLayer();

        [HttpGet("GetAllUsers")]

        public List<User> GetAllUsers()
        {
            return db.GetAllUsers();
        }

        [EnableCors("*", "*", "*")]
        [HttpPost("AddUser")]

        public int AddUser(User a)
        {

            return db.AddUser(a);
        }

        [EnableCors("*", "*", "*")]

        [HttpPost("LoginUser")]

        public User LoginUser(User a)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
          

            //config.EnableCors(cors);
            return db.LoginUser(a);
        }

        [HttpPut("UpdateUser")]

        public int UpdateUser(int id, User c)
        {
            return db.UpdateUser(id, c);
        }


        [HttpDelete("DeleteUser")]

        public int DeleteUser(int id)
        {
            return db.DeleteUser(id);
        }

        [HttpGet("GetUserById")]

        public User GetUserById(int id)
        {
            return db.GetUserById(id);
        }


        [HttpGet("GetAllRoles")]
        public List<Role> GetAllRoles()
        {
            return db.GetAllRoles();
        }

        [HttpPost("AddRole")]
        public int AddRole(Role a)
        {

            return db.AddRole(a);
        }

        [HttpPut("UpdateRole")]
        public int UpdateRole(int id, Role c)
        {
            return db.UpdateRole(id, c);
        }


        [HttpDelete("DeleteRole")]
        public int DeleteRole(int id)
        {
            return db.DeleteRole(id);
        }


        [HttpGet("{id}/GetRoleById")]



        public Role GetRoleById(int id)
        {
            return db.GetRoleById(id);
        }
    }
}
