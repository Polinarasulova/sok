using System.Collections.Generic;

namespace LemonApp
{
    public class TasksService
    {
        public List<TaskReward> GetAvailableTasks()
        {
            return new List<TaskReward>
            {
                new TaskReward { Name = "Add Progress Tree", LemonReward = 100 },
                new TaskReward { Name = "Watch Video", LemonReward = 100 },
                new TaskReward { Name = "Wash Dishes", LemonReward = 300 },
                new TaskReward { Name = "Clean Floors", LemonReward = 400 },
                new TaskReward { Name = "Read 50 Pages", LemonReward = 10000 }
            };
        }
    }
}