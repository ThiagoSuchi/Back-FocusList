using FocusListApi.Database;
using FocusListApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FocusListApi.Services
{
    public class TaskService(AppDbContext appDbContext)
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        // Listar todos
        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _appDbContext.DbTasks.ToListAsync();
        }

        // Criar nova tarefa
        public async Task<TaskModel> PostTask(TaskModelDTO task)
        {
            var taskDuplicate = await _appDbContext.DbTasks.AnyAsync(t => t.Title == task.Title);

            if (taskDuplicate) throw new Exception("Já existe uma tarefa com esse título.");

            var newTask = new TaskModel
            {
                Title = task.Title,
                Completed = task.Completed
            };

            _appDbContext.DbTasks.Add(newTask);
            await _appDbContext.SaveChangesAsync();
            return newTask;
        }

        // Atualizar tarefa
        public async Task<TaskModel> PutTask(int id, TaskModelUpdatingDTO updatedTask)
        {
            var task = await _appDbContext.DbTasks.FindAsync(id);
            
            if (updatedTask.Title != null) task!.Title = updatedTask.Title;
            
            // Usa-se a propriedade .HasValue (para verificar se um valor foi mandado na requisição) e 
            // .Value (para extrair o valor booleano propriamente dito).
            if (updatedTask.Completed.HasValue) task!.Completed = updatedTask.Completed.Value;

            await _appDbContext.SaveChangesAsync();
            return task!;
        }

        // Deletar tarefas
        public async void DeleteTask(int id)
        {
            var task = await _appDbContext.DbTasks.FindAsync(id);

            _appDbContext.DbTasks.Remove(task!);
            await _appDbContext.SaveChangesAsync();
        }
    }
}