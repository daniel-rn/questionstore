using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionStore.Application.Queries
{
    public interface IParticipanteQueries
    {
        Task<ParticipanteViewModel> ObterParticipante(Guid clienteId);
    }
}
