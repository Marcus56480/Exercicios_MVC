using System.ComponentModel.DataAnnotations;

namespace ExerciciosMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome deve conter entre 2 e 80 Caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatoiria")]
        [MinLength(10 , ErrorMessage = "A descrição deve conter pelo menos 10 Caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Local Obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O local deve conter entre 3 e 100 Caracteres")]
        public string? Local { get; set; }

        [Required(ErrorMessage = "A data do evento é obrigatoria")]
        public DateTime DataEvento { get; set; }
  
        [Range(1, 1000, ErrorMessage = "A quantidade de vagas esta entre 1 e 1000")]
        public int QuantidadeVagas { get; set; }

        [Range(0, 100000, ErrorMessage = "O valor minimo do ingresso é R$ 0,00")]
        public decimal ValorIngresso { get; set; }
    }
}