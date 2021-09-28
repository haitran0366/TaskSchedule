using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSchedule.Models;

namespace TaskSchedule.Services
{
    public class TaskService
    {
        private static List<TaskModel> taskList;
        public static List<TaskModel> TaskList
        {
            get { return taskList; }
            set
            {
                taskList = value;
            }
        }

        static TaskService()
        {
            getTask();
        }
        public async static Task<List<TaskModel>> GetAll()
        {
            return await Startup.TaskDatabase.GetAllTaskAsync();
        }
        public async static Task<TaskModel> GetaTask(int id)
        {
            return await Startup.TaskDatabase.GetTaskById(id);
        }
        public async static void Add(TaskModel taskModel)
        {
            await Startup.TaskDatabase.CreateTaskAsync(taskModel);

        }
        public async static void getTask()
        {
            TaskList = await Startup.TaskDatabase.GetAllTaskAsync();
        }

        public static void Delete(TaskModel taskModel)
        {
            Startup.TaskDatabase.DeleteTask(taskModel);
        }
        public async static Task<int> Update(TaskModel taskModel)
        {
            return await Startup.TaskDatabase.UpdateTask(taskModel);
        }
    }
}
