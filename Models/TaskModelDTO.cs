using System.ComponentModel.DataAnnotations;

namespace FocusListApi.Models
{
  public class TaskModelDTO
  {
    [Required(ErrorMessage = "Insira um título, para poder criar a tarefa!")]
    public String Title { get; set; } = string.Empty;

    public Boolean Completed { get; set; }
  }

  public class TaskModelUpdatingDTO
  {
    public String? Title { get; set; }

    public Boolean? Completed { get; set; }
  }
}