using Microsoft.EntityFrameworkCore;
using APICarro.Data;
using APICarro.Controllers;
using Models;

namespace APICarro.Test

{
    public class UnitTestCarro
    {

        private DbContextOptions<APICarroContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<APICarroContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new APICarroContext(options))
            {
                context.Carro.Add(new Carro { Placa = "ABC1234", Nome = "HB20", AnoModelo = 2024, AnoFabricacao = 1970, Cor = "Azul", Vendido = false });
                context.Carro.Add(new Carro { Placa = "DEF5678", Nome = "Creta", AnoModelo = 2023, AnoFabricacao = 1975, Cor = "Preto", Vendido = false });
                context.Carro.Add(new Carro { Placa = "GHI9012", Nome = "Azera", AnoModelo = 2022, AnoFabricacao = 1980, Cor = "Vermelho", Vendido = false });
                context.SaveChanges();
            }
        }
        [Fact]
        public void TestGetAll()
        {
            InitializeDataBase();
            using (var context = new APICarroContext(options))
            {
                CarrosController carrosController = new CarrosController(context);
                IEnumerable<Carro> carros = carrosController.GetCarro().Result.Value;
                Assert.Contains(carros, carro => carro.Placa == "ABC1234");
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();

            using (var context = new APICarroContext(options))
            {
                CarrosController Controller = new CarrosController(context);
                Carro carro = new Carro { Placa = "JKL3456", Nome = "HB20", AnoModelo = 2024, AnoFabricacao = 2023, Cor = "Azul", Vendido = false };
                Carro add = Controller.PostCarro(carro).Result.Value;
                Assert.Equal("JKL3456", add.Placa);
            }
        }
    }
}