using backend.Data;
using backend.Models.Domain;
using backend.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //http://localhost:xxxx/api/taskcolaborator/
    public class TaskColaboratorController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public TaskColaboratorController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTaskColaborator(TaskColaboratorRequestDTO request) 
        {
            //MAP  DTO TO DOMAIN MODEL

            var task_colaborator = new task_colaborator
            {
                title = request.title,
                description = request.description,
                due_date = request.due_date,
                is_complete = request.is_complete,
            };

            await dbContext.task_colaborator.AddAsync(task_colaborator);
            await dbContext.SaveChangesAsync();

            var response = new TaskColaboratorDTO
            {
                task_id = task_colaborator.task_id,
                title = task_colaborator.title,
                description = task_colaborator.description,
                due_date = task_colaborator.due_date,
                is_complete = task_colaborator.is_complete
            };

            return Ok(response);
        }

        // READ ALL
        [HttpGet]
        public async Task<IActionResult> GetAllTaskColaborators()
        {
            var tasks = await dbContext.task_colaborator.ToListAsync();

            var response = tasks.Select(task => new TaskColaboratorDTO
            {
                task_id = task.task_id,
                title = task.title,
                description = task.description,
                due_date = task.due_date,
                is_complete = task.is_complete
            }).ToList();

            return Ok(response);
        }
        // READ BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskColaboratorById(int id)
        {
            var task = await dbContext.task_colaborator.FindAsync(id);

            if (task == null)
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }

            var response = new TaskColaboratorDTO
            {
                task_id = task.task_id,
                title = task.title,
                description = task.description,
                due_date = task.due_date,
                is_complete = task.is_complete
            };

            return Ok(response);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskColaborator(int id, TaskColaboratorRequestDTO request)
        {
            var task = await dbContext.task_colaborator.FindAsync(id);

            if (task == null)
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }

            task.title = request.title;
            task.description = request.description;
            task.due_date = request.due_date;
            task.is_complete = request.is_complete;

            dbContext.task_colaborator.Update(task);
            await dbContext.SaveChangesAsync();

            var response = new TaskColaboratorDTO
            {
                task_id = task.task_id,
                title = task.title,
                description = task.description,
                due_date = task.due_date,
                is_complete = task.is_complete
            };

            return Ok(response);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskColaborator(int id)
        {
            var task = await dbContext.task_colaborator.FindAsync(id);

            if (task == null)
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }

            dbContext.task_colaborator.Remove(task);
            await dbContext.SaveChangesAsync();

            return Ok(new { Message = $"Task with ID {id} has been deleted." });
        }
    }
}
