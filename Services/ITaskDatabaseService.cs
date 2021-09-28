using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSchedule.Models;

namespace TaskSchedule.Services
{
    public interface ITaskDatabaseService<T>
    {
        Task<int> CreateTaskAsync(T taskModel);
        void DeleteTask(T taskModel);
        Task<List<T>> GetAllTaskAsync();
        Task<T> GetTaskById(int id);
        Task<int> UpdateTask(T taskModel);
    }
}