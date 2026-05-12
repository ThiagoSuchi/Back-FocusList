using FocusListApi.Models;
using FocusListApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FocusListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(TaskService service) : ControllerBase
    {
        private readonly TaskService _service = service;

        //Listar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetAllTasks()
        {
            return await _service.GetAllTasks();
        }

        // Criar nova tarefa
        [HttpPost]
        public async Task<IActionResult> PostTask(TaskModelDTO task) 
        {
            // Se os valores da requisição forem inválidos, retorna erro
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTask = await _service.PostTask(task);
            return Created("Tarefa criada com sucesso!", newTask);
        }

        // Atualizar tarefa
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, [FromBody] TaskModelUpdatingDTO task)
        {
            var newTask = await _service.PutTask(id, task);
            return Created("Tarefa Atualizada com sucesso!", newTask);
        }

        // Deletar uma tarefa
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            _service.DeleteTask(id);
            return Ok("Tarefa foi deletada permanentemente!");
        }
    }
}