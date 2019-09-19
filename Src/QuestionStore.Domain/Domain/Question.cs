using QuestionStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionStore.Domain.Domain
{
    public class Question : Entity
    {
        public string Descricao { get; set; }
    }
}
