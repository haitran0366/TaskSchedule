using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSchedule.Models;
using TaskSchedule.Services;

namespace TaskSchedule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAll() => await TaskService.GetAll();

        [HttpPost]
        public IActionResult CreateTask(TaskModel taskModel)
        {
            TaskService.Add(taskModel);
            return CreatedAtAction(nameof(CreateTask), new { taskModel });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var taskModel = await TaskService.GetaTask(id);

            if (taskModel == null)
            {
                return NotFound();
            }
            try
            {
                TaskService.Delete(taskModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TaskModel taskModel)
        {
            if (id != taskModel.ID)
            {
                return BadRequest();
            }

            try
            {
                await TaskService.Update(taskModel);
            }
            catch (Exception ex)
            {

                return NotFound();

            }
            return NoContent();
        }
    }
}
