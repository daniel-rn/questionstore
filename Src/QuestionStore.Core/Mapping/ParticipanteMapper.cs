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
            var com = (InsertParticipanteCommand)command;
            using (var transacao = Connection.ObtenhaFbTransaction())
            using (var cmd = Connection.ObtenhaComando())
            {
                var id = Guid.NewGuid().ToString().ToCharArray().Take(32);
                var id2 = string.Concat(id);
                cmd.CommandText = $@"INSERT INTO PARTICIPANTE (PARTCODIGO, PARTNAME) VALUES ('{id2}', '{com.Nome}');";

                cmd.ExecuteNonQuery();

                transacao.Commit();
                transacao.Connection.Close();
            }
        }
    }
}
