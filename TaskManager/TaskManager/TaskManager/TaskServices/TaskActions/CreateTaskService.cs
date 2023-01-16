using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DataBaseConfiguration;

namespace TaskManager.TaskServices.TaskActions
{
    internal class CreateTaskService : ICreateTaskService
    {
        private readonly IDbStorage _storage;

        public CreateTaskService(IDbStorage storage)
        {
            _storage = storage;
        }
        
        public void DoAction()
        {
            Console.WriteLine("Название новой задачи");
            var task = new Tasks { Name = Console.ReadLine(), Status = "В плане"};
            _storage.Tasks.Add(task);
            _storage.Save();
            Console.WriteLine("Задача создана");
        }
    }
}
