using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataBaseConfiguration;
using TaskManager.TaskServices.TaskActions;

class MenuService : IMenuService
{
    private readonly IDbStorage _storage;
    private readonly ICreateTaskService _createTaskService;
    private readonly IShowTasksService _showTasksService;
    private readonly IChangeStatusService _changeStatusService;
    private readonly IValidator _validator;

    public MenuService(IDbStorage storage, ICreateTaskService createService,
        IShowTasksService showService, IChangeStatusService changeStatusService, IValidator validator)
    {
        _storage = storage;
        _createTaskService = createService;
        _showTasksService = showService;
        _changeStatusService = changeStatusService;
        _validator = validator;
    }


    void Message()
    {
        Console.Clear();
        Console.WriteLine("Выберите действие");
        Console.WriteLine("1 - Создание");
        Console.WriteLine("2 - Показать задачи");
        Console.WriteLine("3 - Смена статуса");
        Console.WriteLine("Любая другая кнопка - закрыть приложение");
    }

    public void StartMainMenu()
    {
        bool isFinish = true;

        while (isFinish)
        {
            Message();
            int key = _validator.Validation();

            switch (key)
            {
                case (int)Actions.FirstAction:
                    Console.Clear();
                    _createTaskService.DoAction();
                    Console.ReadKey();
                    break;
                case (int)Actions.SecondAction:
                    Console.Clear();
                    _showTasksService.DoAction();
                    Console.ReadKey();
                    break;
                case (int)Actions.ThirdAction:
                    Console.Clear();
                    _showTasksService.DoAction();
                    _changeStatusService.DoAction();
                    Console.ReadKey();
                    break;
                default:
                    isFinish = false;
                    break;

            }
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
