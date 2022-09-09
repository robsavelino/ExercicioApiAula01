using System.ComponentModel.DataAnnotations;
namespace Aula01Api.Core.Model
{
    public class Client
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Cpf � obrigat�rio")]
        [StringLength(14, ErrorMessage = "Cpf deve conter 14 caracteres", MinimumLength = 14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de naschimeto � obrigat�ria")]
        public DateTime DataNascimento { get; set; }
        public int Age
        {
            get
            {
                int Age = (int)(DateTime.Today - DataNascimento).TotalDays;
                Age = Age / 365;
                return Age;
            }
        }

    }
}



