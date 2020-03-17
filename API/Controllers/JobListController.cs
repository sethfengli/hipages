using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.JobList.Querieies;
using Application.Common.JobList.DTO;
using Application.Common.JobList.Commands;

namespace API.Controllers
{
    public class JobListController : ApiController
    {
        // GET: api/JobList/new
        [HttpGet("{Status}", Name = "Get")]
        public async Task<IList<JobItemDTO>> Get(string Status)
        {
            return await Mediator.Send(new GetJobListQuery { status = Status });

        }

        // PUT: api/JobList/1  
        // Json Body link this
        // {
        //	"id":1,
        //	"status":"accepted"
        // }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateJobItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
