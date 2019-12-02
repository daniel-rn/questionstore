using QuestionStore.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

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
    }


    public interface IServiceParticipante : IDisposable
    {
        void Insert(Command command);
    }
}
