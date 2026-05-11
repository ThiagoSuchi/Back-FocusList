using System.ComponentModel.DataAnnotations;

namespace FocusListApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Insira um título, para poder criar a tarefa!")]
        public String Title { get; set; }

        public Boolean Completed { get; set; }
    }
}