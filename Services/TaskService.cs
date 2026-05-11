using FocusListApi.Database;
using FocusListApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusListApi.Services
{
    public class TaskService
    {
        private readonly AppDbContext _appDbContext;

        // DI
        public TaskService(AppDbContext appDbContext) => _appDbContext = appDbContext;

        // Listar todos
        public async Task<List<TaskModel>> getAllTasks()
        {
            return await _appDbContext.DbTasks.ToListAsync();
        }

        // Criar nova tarefa
        public async Task<TaskModel> postTask(TaskModel task)
        {
            var taskDuplicate = await _appDbContext.DbTasks.AnyAsync(t => t.Title == task.Title);

            if (taskDuplicate) throw new Exception("Já existe uma tarefa com esse título.");

            _appDbContext.DbTasks.Add(task);
            await _appDbContext.SaveChangesAsync();
            return task;
        }

        // Atualizar tarefa
        // public async Task<TaskModel> putTask(int id, TaskModel updatedTask)
        // {
        //     var task = await _appDbContext.DbTasks.FindAsync(id);


        // }
    }
}