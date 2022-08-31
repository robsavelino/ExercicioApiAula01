using System.ComponentModel.DataAnnotations;
namespace Aula01Api
{
    public class Cadastro
    {
        [Required(ErrorMessage = "Cpf � obrigat�rio")]
        [StringLength(11, ErrorMessage = "Cpf deve conter 11 caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data de naschimeto � obrigat�ria")]
        public DateTime BirthDate { get; set; }
        public int Age { get {return DateTime.Now.Year - BirthDate.Year;} }   

    }
    
}
}