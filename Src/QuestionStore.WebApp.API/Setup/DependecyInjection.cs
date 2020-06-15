using Microsoft.Extensions.DependencyInjection;
using QuestionStore.Core.Data;
using QuestionStore.Core.Mapping;
using QuestionStore.Core.Service;

namespace QuestionStore.WebApp.API.Setup
{
    public static class DependecyInjection
    {

        public static void RegistreServicos(this IServiceCollection servicos)
        {
            //Services
            servicos.AddScoped<IServiceAnswer, ServiceAnswer>();
            servicos.AddScoped<IServiceParticipante, ServicoCadastroParticipante>();

            //Mappers
            servicos.AddScoped<IMapper, AnswerMapper>();
            servicos.AddScoped<IMapperParticipante, ParticipanteMapper>();

            //Connection
            servicos.AddScoped<IConnection, Connection>();
        }
    }
}
