
using ApiLocal._0._0_._Entities.General.Response;
using ApiLocal._2._0.__Business;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLocal._3._0_.__UI
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectController : ControllerBase
    {
        private readonly Projects context;

        public ProjectController(Projects context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all projects of team
        /// </summary>
        [HttpGet("getProjects")]
        public ActionResult<ResponseAll> getProjects()
        {
            return this.context.GetProjects(HttpContext);
        }

    }
}
