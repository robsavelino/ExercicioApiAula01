using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula01Api.Repositories
{
    public class ClientsRepositories
    {
        private readonly IConfiguration _configuration;
        
        public ClientsRepositories(IConfiguration cofiguration)
        {
            _configuration = cofiguration;
        }
        public List<Clients> GetClients()
        {
            var query = "SELECT * FROM Clientes";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Clients>(query).ToList();
        }
        public Clients GetClient(long id)
        {
            var query = "SELECT * FROM Clientes WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.QuerySingleOrDefault<Clients>(query, parameters);
        }
        public bool InsertClient(Clients client)
        {
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @age)";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", client.Cpf);
            parameters.Add("nome", client.Nome);
            parameters.Add("dataNascimento", client.DataNascimento);
            parameters.Add("age", client.Age);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, parameters) == 1;
              
        }

        public bool UpdateClient(Clients client, long id)
        {
            var query = "UPDATE Clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            parameters.Add("cpf", client.Cpf);
            parameters.Add("nome", client.Nome);
            parameters.Add("dataNascimento", client.DataNascimento);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteClient(long id)
        {
            var query = "DELETE from Clientes WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }


    }

}
