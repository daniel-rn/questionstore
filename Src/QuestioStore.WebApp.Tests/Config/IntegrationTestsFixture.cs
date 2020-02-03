
using Microsoft.AspNetCore.Mvc.Testing;
using QuestionStore.WebApp.API;
using QuestionStore.WebApp.MVC;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Xunit;

namespace QuestioStore.WebApp.Tests.Config
{
    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollection))]
    public class IntegrationWebTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupMVC>> { }

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupAPI>> { }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly LojaAppFactory<TStartup> Factory;
        public HttpClient Client;

        public string AntiForgeryFieldName = "__RequestVerificationToken";

        
        public IntegrationTestsFixture()
        {
            Factory = new LojaAppFactory<TStartup>();
            Client = Factory.CreateDefaultClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }

        public string ObterAntiForgeryToken(string htmlBody)
        {
            var requestVerificationTokenMatch =
             Regex.Match(htmlBody, $@"\<input name=""{AntiForgeryFieldName}"" type=""hidden"" value=""([^""]+)"" \/\>");

            if (requestVerificationTokenMatch.Success)
            {
                return requestVerificationTokenMatch.Groups[1].Captures[0].Value;
            }

            throw new ArgumentException($"Anti forgery token '{AntiForgeryFieldName}' não encontrado no HTML", nameof(htmlBody));
        }
    }
}