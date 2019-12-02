using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.MVC.Models
{
    public class CadastroParticipanteModel
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "seu saraiva";

        public int Idade { get; set; }
    }
}
