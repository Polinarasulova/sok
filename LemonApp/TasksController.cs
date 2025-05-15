using Microsoft.AspNetCore.Mvc;

namespace LemonApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TasksService _tasksService;
        private readonly UserService _userService;

        public TasksController(TasksService tasksService, UserService userService)
        {
            _tasksService = tasksService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_tasksService.GetAvailableTasks());
        }

        [HttpPost("{username}/{taskName}")]
        public IActionResult CompleteTask(string username, string taskName)
        {
            var tasks = _tasksService.GetAvailableTasks();
            var task = tasks.FirstOrDefault(t => t.Name == taskName);

            if (task == null)
                return NotFound("Задание не найдено");

            var user = _userService.AddLemons(username, task.LemonReward);

            return Ok(new
            {
                Message = $"Вы получили {task.LemonReward} лимонов за '{taskName}'",
                TotalLemons = user.Lemons
            });
        }
    }
}