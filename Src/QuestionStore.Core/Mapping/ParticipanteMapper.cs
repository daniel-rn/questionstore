using ControleFamiliar.Mapeadores;
using QuestionStore.Core.Service;

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
                var id = com.Id.ToString().Replace('-', ' ').Trim();
                cmd.CommandText = $@"INSERT INTO PARTICIPANTE (PARTCODIGO, PARTNAME) VALUES ({id}, {com.Nome});";

                cmd.ExecuteNonQuery();

                transacao.Commit();
                transacao.Connection.Close();
            }
        }
    }
}
