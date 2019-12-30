using ControleFamiliar.Mapeadores;
using QuestionStore.Core.Service;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using QuestionStore.Core.Data;

namespace QuestionStore.Core.Mapping
{
    public class ParticipanteMapper : IMapper
    {
        private readonly IConfiguration _configuration;

        public ParticipanteMapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Insert(Command command)
        {
            var comando = (InsertParticipanteCommand)command;

            using (var con = new Connection2(_configuration))
            using (var transacao = con.ObtenhaFbTransaction())
            using (var cmd = con.ObtenhaComando())
            {
                cmd.Transaction = transacao;

                var identificador = Guid.NewGuid().ObtenhaGuid();
                cmd.CommandText = $@"INSERT INTO PARTICIPANTE (PARTCODIGO, PARTNAME) VALUES ('{identificador}', '{comando.Nome}');";
                cmd.ExecuteNonQuery();
                
                transacao.Commit();
            }
        }
    }
    public interface IMapper
    {
        void Insert(Command command);
    }
}
