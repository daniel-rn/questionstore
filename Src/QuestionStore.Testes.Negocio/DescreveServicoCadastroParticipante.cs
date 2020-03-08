using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Mapping;
using QuestionStore.Core.Service;
using System.Threading.Tasks;

namespace QuestionStore.Testes.Negocio
{
    [TestFixture]
    public class DescreveServicoCadastroParticipante
    {
        [Test]
        [Category("Teste de Mapeadores")]
        public void Deve_realizar_insercao_de_participante_utilizando_mapeador()
        {
            //Arrange 
            var map = new Mock<IMapperParticipante>();
            var srv = new ServicoCadastroParticipante(map.Object);

            var command = new InsertParticipanteCommand()
            {
                Id =  10,
                Nome = "Jose da Silva"
            };

            //Act
            var tarefa = Task.Factory.StartNew(async () =>
            {
                await srv.Insert(command);
            });

            var resultado = tarefa.Result;

            //Assert
            map.Verify(m => m.Insert(command), Times.Once);
        }

        [Test]
        [Ignore("Exemplo de skipe teste for NUnit")] 
        public void Deve_ser_ignorado()
        {
            Assert.Pass();
        }
    }
}
