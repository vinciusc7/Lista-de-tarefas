using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tarefas.Models
{
    public class TarefasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarefaId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Tarefa { get; set; }
        public bool Status { get; set; }
    }
}
