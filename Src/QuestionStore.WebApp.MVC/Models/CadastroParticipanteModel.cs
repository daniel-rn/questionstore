using System.ComponentModel.DataAnnotations;

namespace QuestionStore.WebApp.MVC.Models
{
    public class CadastroParticipanteModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = "seu saraiva";

        public int Idade { get; set; }

        public string Telefone { get; set; }

        public string Rua { get; set; }

        public string Cep { get; set; }

        public string CPF { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

    }
}
