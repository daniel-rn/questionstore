using Microsoft.Extensions.Configuration;
using QuestionStore.Core.Data;
using QuestionStore.Core.Service;
using System;
using System.Collections.Generic;

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

            using (var con = Connection.Factory.Crie(_configuration))
            using (var cmd = con.ObtenhaComando())
            {
                var identificador = Guid.NewGuid().ObtenhaGuid();

                cmd.CommandText = $@"INSERT INTO PARTICIPANTE (PARTCODIGO, PARTNAME) VALUES (@PARTCODIGO, @PARTNAME)";
                cmd.AddParametersToCommand(new[] { "@PARTCODIGO", "@PARTNAME" });
                cmd.AddValuesToParameters(new List<object> { identificador, comando.Nome });
                cmd.ExecuteNonQuery();

                cmd.Commit();
            }
        }
    }
    public interface IMapper
    {
        void Insert(Command command);
    }
}
