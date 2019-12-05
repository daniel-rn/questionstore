using QuestionStore.Core.Service;
using System;
using System.Threading.Tasks;

namespace QuestionStore.Application.Queries
{
    public class ParticipanteQueries : IParticipanteQueries
    {
        private IServiceParticipante _serviceParticipante;

        public ParticipanteQueries(IServiceParticipante ServiceParticipante)
        {
            _serviceParticipante = ServiceParticipante;
        }

        public async Task<ParticipanteViewModel> ObterParticipante(Guid clienteId)
        {
            var participante = await _serviceParticipante.Consulte();

            var participanteModel = new ParticipanteViewModel()
            {
                Nome = participante.Nome
            };

            return participanteModel;
        }
    }
}
