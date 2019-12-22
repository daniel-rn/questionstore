using Microsoft.Extensions.DependencyInjection;
using QuestionStore.Core.Mapping;
using QuestionStore.Core.Service;

namespace QuestionStore.WebApp.MVC.Setup
{
    public static class DependecyInjection
    {

        public static void RegistreServicos(this IServiceCollection servicos)
        {
            //Questoes
            servicos.AddScoped<IServiceAnswer, ServiceAnswer>();
            servicos.AddScoped<IServiceParticipante, ServicoCadastroParticipante>();

            //Mappers
            servicos.AddScoped<IMapper, ParticipanteMapper>();
        }
    }
}
