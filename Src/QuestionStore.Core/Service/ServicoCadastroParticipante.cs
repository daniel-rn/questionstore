using QuestionStore.Core.Mapping;
using QuestionStore.Domain.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuestionStore.Core.Service
{
    public class ServicoCadastroParticipante : IServiceParticipante
    {
        public ServicoCadastroParticipante()
        {
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        

        public async Task<Participante> Consulte()
        {
            return await Task.Run(() =>
            {
                return new Participante() { Nome = "Nasa!" };
            });
        }

        public async Task<bool> Insert(Command command)
        {
            return await Task.Run(() =>
            {
                new ParticipanteMapper().Insert(command);
                return true;
            });
        }
    }


    public interface IServiceParticipante : IDisposable
    {
        Task<bool> Insert(Command command);

        Task<Participante> Consulte();
    }
}
