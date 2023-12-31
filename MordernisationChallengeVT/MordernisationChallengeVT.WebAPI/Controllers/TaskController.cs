using Microsoft.AspNetCore.Mvc;
using ModernisationChallengeVT.Contracts.Businesses;
using ModernisationChallengeVT.Contracts.DTOs;

namespace ModernisationChallengeVT.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskBusiness _taskBusiness;

        public TaskController(ITaskBusiness taskBusiness)
        {
            this._taskBusiness = taskBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDTO>>> GetTasks()
        {
            var tasks = await _taskBusiness.List();

            return tasks;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _taskBusiness.GetById(id);

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskDTO task)
        {
            await _taskBusiness.Create(task);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskDTO task)
        {
            await _taskBusiness.Update(task);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskBusiness.Delete(id);

            return Ok();
        }

        [HttpPost("complete")]
        public async Task<IActionResult> Complete(TaskDTO task)
        {
            await _taskBusiness.CompleteTask(task);

            return Ok();
        }
    }
}