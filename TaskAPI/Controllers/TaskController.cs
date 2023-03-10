using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskAPI.Data;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Task>>> GetTasks()
        {
            return Ok(await _context.Tasktable.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Task>>> CreateTask(Task task)
        {
            _context.Tasktable.Add(task);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tasktable.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Task>>> UpdateTask(Task task)
        {
            var dbTask = await _context.Tasktable.FindAsync(task.TaskId);
            if (dbTask == null)
            {
                return BadRequest("Task not found");
            }
            dbTask.Title = task.Title;
            dbTask.Description = task.Description;
            dbTask.Status = task.Status;
            dbTask.Priority= task.Priority;
            dbTask.DueDate= task.DueDate;

            await _context.SaveChangesAsync();

            return Ok(await _context.Tasktable.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Task>>> DeleteTask(int id)
        {
            var dbTask = await _context.Tasktable.FindAsync(id);
            if (dbTask == null)
            {
                return BadRequest("Task not found");
            }

            _context.Tasktable.Remove(dbTask);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tasktable.ToListAsync());

        }
    }
}
