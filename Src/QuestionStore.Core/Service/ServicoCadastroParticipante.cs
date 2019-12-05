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

        public void Insert(Command command)
        {
            //throw new NotImplementedException(" erro qualquer");
        }

        public async Task<Participante> Consulte()
        {
            Thread.Sleep(5000);

            return await Task.Run(() =>
            {
                return new Participante() { Nome = "Nasa!" };
            });
        }
    }


    public interface IServiceParticipante : IDisposable
    {
        void Insert(Command command);

        Task<Participante> Consulte();
    }
}
