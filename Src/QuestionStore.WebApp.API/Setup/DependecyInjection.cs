using Microsoft.Extensions.DependencyInjection;
using QuestionStore.Core.Data;
using QuestionStore.Core.Mapping;
using QuestionStore.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.API.Setup
{
    public static class DependecyInjection
    {

        public static void RegistreServicos(this IServiceCollection servicos)
        {
            //Questoes
            servicos.AddScoped<IServiceAnswer, ServiceAnswer>();

            //Mappers
            servicos.AddScoped<IMapper, AnswerMapper>();
            servicos.AddScoped<IConnection, Connection>();
        }
    }
}
