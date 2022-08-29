using Microsoft.AspNetCore.Mvc;

namespace Aula01Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Roberto Avelino", "Denison Barbosa", "Matheus Alencastro", "Lugan Thierry", "Amanda Mantovani"};
        private static readonly string[] Cpfs = new[]
        {
        "01232242323", "12312254256", "12453266367", "53266785898", "23133457677"};
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
        public ActionResult<List<Cadastro>> GetCadastros()
        {
            return Ok(Cadastros);
        }
        [HttpPost]
        public ActionResult<Cadastro> PostCadastro(Cadastro novoCadastro)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Cadastros.Add(novoCadastro);
            return CreatedAtAction(nameof(PostCadastro), novoCadastro);
        }
        [HttpPut]
        public IActionResult PutCadastro (string cpf, Cadastro novoCadastro)
        {
            var index = Cadastros.FindIndex(x => x.Cpf == cpf);
            Cadastros[index] = novoCadastro;
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteCadastro (string cpf)
        {
            var index = Cadastros.FindIndex(x => x.Cpf == cpf);
            Cadastros.RemoveAt(index);
            return Ok();
        }
    }
}