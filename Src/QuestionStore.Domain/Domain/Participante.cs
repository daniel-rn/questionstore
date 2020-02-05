using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionStore.Domain.Domain
{
    public class Participante : Entity
    {
        public string Id
        {
            get { return base.Guid.ToString(); }
            set { base.Guid = Guid.Parse(value); }
        }

        public String Nome { get; set; }

        public int Idade { get; set; }

        public string CpfCnpj { get; set; }

        #region Overrides
        public override bool Equals(object obj)
        {
            var participante = obj as Participante;

            return participante != null
                && Id == participante.Id
                && CpfCnpj == participante.CpfCnpj;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CpfCnpj);
        }

        public override string ToString()
        {
            return $"Nome :{this.Nome} CPF :{this.CpfCnpj}";
        }

        #endregion
    }
}
