using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataBaseConfiguration;

namespace TaskManager.TaskServices.TaskActions
{
    internal class ShowTasksService : IShowTasksService
    {
        private readonly IDbStorage _storage;

        public ShowTasksService(IDbStorage storage)
        {
            _storage = storage;

        }

        public void DoAction()
        {
            Console.WriteLine("Список задач\n");
            var tasks = _storage.Tasks.Select(p => p);
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id}.{task.Name} - " +
                    $"({task.Status}) Затрачено времени " +
                    $"{(task.DateTime.Hours)}:{(task.DateTime.Minutes)}:{(task.DateTime.Seconds)}\n");
            }
        }
    }
}
