using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskServices.TaskActions
{
    internal class Validator : IValidator
    {
        public int Validation()
        {
            var inputData = Console.ReadLine();
            if (int.TryParse(inputData, out int id))
            {
                return id;
            }
            return -1;
        }

    }
}
