using Moq;
using NUnit.Framework;
using QuestionStore.Core.Mapping;
using QuestionStore.Core.Service;
using System.Threading.Tasks;

namespace QuestionStore.Testes.Negocio
{
    [TestFixture]
    public class DescreveServicoCadastroParticipante
    {
        [Test(Description = "teste qualquer"), Category("Teste de Mapeadores")]
        public void Deve_realizar_insercao_de_participante_utilizando_mapeador()
        {
            //Arrange 
            var map = new Mock<IMapper>();
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
    }
}
