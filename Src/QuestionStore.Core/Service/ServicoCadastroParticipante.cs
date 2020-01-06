using QuestionStore.Core.Mapping;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionStore.Core.Service
{
    public class ServicoCadastroParticipante : IServiceParticipante
    {
        private readonly IMapper ParticipanteMapper;

        public ServicoCadastroParticipante(IMapper participanteMapper)
        {
            ParticipanteMapper = participanteMapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Participante>> Consulte()
        {
            //return await Task.Run(() =>
            //{
            //    var list = new List<Participante>() { new Participante() { Nome = "Nasa!" } , new Participante() { Nome = "CIA" } };
            //    return list;
            //});

            return await Task.Run(() =>
            {
                ParticipanteMapper.Insert
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
