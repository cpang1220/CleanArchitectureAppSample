using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JediAcademy.Back.Application.Queries;
using JediAcademy.Back.Domain.Entities;

namespace JediAcademy.Back.Api.Controllers
{
    [ApiController]
    [Route("api/individuals")]
    public class IndividualsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndividualsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var (isSuccess, jediStudents, message) = await _mediator.Send(new GetStudents.Query());
            if (isSuccess)
            {
                return Ok(jediStudents);
            }
            return jediStudents != null ?
                NotFound(message) :
                StatusCode(500, message);
        }

        // Edited by CPang 2020-07-15 Challenge 2
        [HttpPost]
        public async Task<ActionResult<JediStudent>> CreateStudent(AddStudent.CreateRequest request)
        {
            var(isSuccess, jediStudent, message) = await _mediator.Send(request);
            if (isSuccess)
            {
                return Ok(jediStudent);
            }
            return jediStudent != null ?
               NotFound(message) :
               StatusCode(500, message);
        }
    }
}
