namespace Aula01Api
{
    public class Cadastro
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get {return DateTime.Now.Year - BirthDate.Year;} }   

    }
    
}