using QuestionStore.WebApp.MVC;
using QuestioStore.WebApp.Tests.Config;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace QuestioStore.WebApp.Tests
{
    [Collection(nameof(IntegrationWebTestsFixtureCollection))]
    public class UsuarioTests
    {
        private readonly IntegrationTestsFixture<StartupMVC> _testsFixture;

        public UsuarioTests(IntegrationTestsFixture<StartupMVC> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Realizar cadastro com sucesso")]
        [Trait("Categoria", "Integração Web - Usuário")]
        public async Task Usuario_RealizarCadastro_DeveExecutarComSucesso()
        {
            // Arrange
            var initialResponse = await _testsFixture.Client.GetAsync("/CadastroParticipante");
            initialResponse.EnsureSuccessStatusCode();

            var formData = new Dictionary<string, string>
            {
                {"Nome", "Macelé Goiano"},
                {"Idade", "24" },
                {"CPF","01234567890"}
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/CadastroParticipante")
            {
                Content = new FormUrlEncodedContent(formData)
            };

            // Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);
            postResponse.EnsureSuccessStatusCode();
        }
    }
}
