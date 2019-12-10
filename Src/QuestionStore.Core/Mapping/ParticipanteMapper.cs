using ControleFamiliar.Mapeadores;
using QuestionStore.Core.Service;
using System;
using System.Linq;

namespace QuestionStore.Core.Mapping
{
    public class ParticipanteMapper
    {
        internal void Insert(Command command)
        {
            var comando = (InsertParticipanteCommand)command;
            using (var transacao = Connection.ObtenhaFbTransaction())
            using (var cmd = Connection.ObtenhaComando())
            {
                var identificador = Guid.NewGuid().ObtenhaGuid();
                cmd.CommandText = $@"INSERT INTO PARTICIPANTE (PARTCODIGO, PARTNAME) VALUES ('{identificador}', '{comando.Nome}');";
                cmd.ExecuteNonQuery();
                transacao.Commit();
            }
        }
    }
}
