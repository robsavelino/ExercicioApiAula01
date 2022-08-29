using Microsoft.AspNetCore.Mvc;

namespace Aula01Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Roberto Avelino", "Denison Barbosa", "Matheus Alencastro", "Lugan Thierry", "Amanda Mantovani"
        };
        private static readonly string[] Cpfs = new[]
        {
        "012.322.423-23", "123.122.542-56", "124.532.663-67", "532.667.858-98", "231.334.576.77"
        };
        private static DateTime RandomDate()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var year = rnd.Next(1970, 2000);
            var month = rnd.Next(1, 13);
            var days = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, days,
            rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60), rnd.Next(0, 1000));
        }


        public List<Cadastro> Cadastros { get; set; } = new();
        public CadastroController()
        {
            Cadastros = Enumerable.Range(1, 5).Select(index => new Cadastro
            {
                Cpf = Cpfs[index - 1],
                Name = Names[index - 1],
                BirthDate = RandomDate()
            })
            .ToList();
        }

        [HttpGet]
        public List<Cadastro> GetCadastros()
        {
            return Cadastros;
        }
        [HttpPost]
        public Cadastro PostCadastro(Cadastro novoCadastro)
        {
            Cadastros.Add(novoCadastro);
            return Cadastros.Last();
        }
        [HttpPut]
        public Cadastro PutCadastro (string cpf, Cadastro novoCadastro)
        {
            var index = Cadastros.FindIndex(x => x.Cpf == cpf);
            Cadastros[index] = novoCadastro;
            return Cadastros[index];
        }

        [HttpDelete]
        public List<Cadastro> DeleteCadastro (string cpf)
        {
            var index = Cadastros.FindIndex(x => x.Cpf == cpf);
            Cadastros.RemoveAt(index);
            return Cadastros;
        }
    }
}