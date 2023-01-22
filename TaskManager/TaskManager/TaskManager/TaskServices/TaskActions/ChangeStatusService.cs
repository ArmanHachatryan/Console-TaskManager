using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataBaseConfiguration;

namespace TaskManager.TaskServices.TaskActions
{
    internal class ChangeStatusService : IChangeStatusService
    {
        private readonly IDbStorage _storage;
        private readonly IValidator _validator;

        public ChangeStatusService(IDbStorage storage, IValidator validator)
        {
            _storage = storage;
            _validator = validator;
        }

        public void DoAction()
        {
            Console.WriteLine("Выбери задачу");
            int id = _validator.Validation();
            var task = _storage.Tasks.FirstOrDefault(p => p.Id == id);

            if (task != null)
            {
                Console.WriteLine("Выбери на какой статус заменить");
                Console.WriteLine("1. Выполняется\n2. Остановлено \n3. Завершено ");
                int key = _validator.Validation();

                switch (key)
                {
                    case (int)Actions.FirstAction:
                        task.Status = "Выполняется";
                        task.StartDate = DateTime.Now;
                        break;
                    case (int)Actions.SecondAction:
                        task.Status = "Остановлено";
                        task.EndDate = DateTime.Now;
                        task.DateTime += task.EndDate.Subtract(task.StartDate);
                        break;
                    case (int)Actions.ThirdAction:
                        task.Status = "Завершено";
                        task.EndDate = DateTime.Now;
                        task.DateTime += task.EndDate.Subtract(task.StartDate);
                        break;
                    default:
                        Console.WriteLine("Неверные данные");
                        break;
                }
                _storage.Save();
            }
            else
            {
                Console.WriteLine("Такой Задачи нет");
            }

        }

        enum Actions
        {
            Zero,
            FirstAction,
            SecondAction,
            ThirdAction,
        }
    }

}
