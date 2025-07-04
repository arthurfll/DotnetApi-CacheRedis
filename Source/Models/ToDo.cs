using System.ComponentModel.DataAnnotations;

namespace Source.Models;

public class ToDo
{
  [Key]
  public Guid Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string Title { get; set; } = "";

  [Required]
  [MaxLength(200)]
  public string Text { get; set; } = "";
}

