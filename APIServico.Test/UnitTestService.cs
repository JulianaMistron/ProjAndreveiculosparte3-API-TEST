using APIServico.Controllers;
using APIServico.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIServico.Test
{
    public class UnitTestCarro
    {

        private DbContextOptions<APIServicoContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<APIServicoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new APIServicoContext(options))
            {
                context.Servico.Add(new Servico { Id = 1, Descricao = "Lavagem" });
                context.Servico.Add(new Servico { Id = 2, Descricao = "Alinhamento" });
                context.Servico.Add(new Servico { Id = 3, Descricao = "Balanceamento" });
                context.SaveChanges();
            }
        }
        [Fact]
        public void TestGetAll()
        {
            InitializeDataBase();
            using (var context = new APIServicoContext(options))
            {
                ServicosController servicosController = new ServicosController(context);
                IEnumerable<Servico> servicos = servicosController.GetServico().Result.Value;
                Assert.Contains(servicos, servico => servico.Id == 1);
            }
        }

        [Fact]
        public void TestGetById()
        {
            InitializeDataBase();
            using (var context = new APIServicoContext(options))
            {
                ServicosController servicosController = new ServicosController(context);
                Servico servico = servicosController.GetServico(2).Result.Value;
                Assert.Equal(2, servico.Id);

            }
        }
        //[Fact]
        //public void Create()
        //{
        //    InitializeDataBase();

        //    using (var context = new APIServicoContext(options))
        //    {
        //        ServicosController Controller = new ServicosController(context);
        //        Servico servico = new Servico { Id = 4, Descricao = "Troca óleo" };
        //        Servico add = Controller.PostServico(servico).Result.Value;
        //        Assert.(4, add.Id);
        //    }
        //}
    }
}