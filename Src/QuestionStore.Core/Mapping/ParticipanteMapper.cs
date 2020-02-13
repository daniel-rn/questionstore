using Microsoft.Extensions.Configuration;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Data;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace QuestionStore.Core.Mapping
{
    public class ParticipanteMapper : IMapperParticipante
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
                var identificador = Guid.NewGuid().ToString();

                cmd.CommandText =
$@"INSERT INTO PARTICIPANTE (PARTCODIGO, PARTNAME, PARTIDADE, PARTCPF) 
VALUES (@PARTCODIGO, @PARTNAME, @PARTIDADE, @PARTCPF)";

                cmd.AddParametersToCommand(new[] { "@PARTCODIGO", "@PARTNAME", "@PARTIDADE", "@PARTCPF" });
                cmd.AddValuesToParameters(new List<object> { identificador, comando.Nome, comando.Idade, comando.Cpf });
                cmd.ExecuteNonQuery();

                cmd.Commit();
            }
        }

        public IEnumerable<Participante> Consulte()
        {
            var participantes = new List<Participante>();

            using (var con = Connection.Factory.Crie(_configuration))
            using (var cmd = con.ObtenhaComando())
            {
                cmd.CommandText = "SELECT PARTNAME, PARTIDADE, PARTCPF, PARTCODIGO FROM PARTICIPANTE";

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        participantes.Add(Mapeie(dr));
                    }
                }
            }

            return participantes;
        }

        private static Participante Mapeie(DbDataReader dr)
        {
            return new Participante
            {
                Nome = dr.GetString(0),
                Idade = dr.GetInt16(1),
                CpfCnpj = dr.GetString(2),
                Id = dr.GetString(3),
            };
        }
    }

    public interface IMapperParticipante : IMapper
    {
        IEnumerable<Participante> Consulte();
    }

}
