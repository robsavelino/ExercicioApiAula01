using System.ComponentModel.DataAnnotations;
namespace Aula01Api
{
    public class Cadastro
    {
        [Required(ErrorMessage = "Cpf é obrigatório")]
        [StringLength(11, ErrorMessage = "Cpf deve conter 11 caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data de naschimeto é obrigatória")]
        public DateTime BirthDate { get; set; }
        public int Age { get {return DateTime.Now.Year - BirthDate.Year;} }   

    }
    
}
}