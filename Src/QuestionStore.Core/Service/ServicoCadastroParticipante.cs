using QuestionStore.Core.Commands;
using QuestionStore.Core.Mapping;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionStore.Core.Service
{
    public class ServicoCadastroParticipante : IServiceParticipante
    {
        private readonly IMapperParticipante ParticipanteMapper;

        public ServicoCadastroParticipante(IMapperParticipante participanteMapper)
        {
            ParticipanteMapper = participanteMapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Participante>> Consulte()
        {
            return await Task.Run(() =>
            {
                return ParticipanteMapper
                .Consulte()
                .ToList();
            });
        }

        public async Task<bool> Insert(Command command)
        {
            return await Task.Run(() =>
            {
                ParticipanteMapper.Insert(command);
                return true;
            });
        }
    }

    public interface IServiceParticipante : IDisposable
    {
        Task<bool> Insert(Command command);

        Task<List<Participante>> Consulte();
    }
}
