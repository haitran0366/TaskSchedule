using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSchedule.Models;

namespace TaskSchedule.Services
{
    public class TaskDatabaseService : ITaskDatabaseService<TaskModel>
    {
        readonly SQLite.SQLiteAsyncConnection _database;

        public TaskDatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskModel>().Wait();
        }

        public Task<List<TaskModel>> GetAllTaskAsync()
        {
            return _database.Table<TaskModel>().OrderByDescending(x => x.DueDate).ToListAsync();
        }

        public Task<int> CreateTaskAsync(TaskModel taskModel)
        {
            return _database.InsertAsync(taskModel);

        }
        public async void DeleteTask(TaskModel taskModel)
        {
            await _database.DeleteAsync(taskModel);
        }
        public async Task<int> UpdateTask(TaskModel taskModel)
        {
            return await _database.UpdateAsync(taskModel);
        }
        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _database.FindAsync<TaskModel>(id);
        }
    }
}
