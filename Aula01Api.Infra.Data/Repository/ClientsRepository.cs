using Dapper;
using Microsoft.Data.SqlClient;
using Aula01Api.Core.Model;
using Microsoft.Extensions.Configuration;
using Aula01Api.Core.Interfaces;

namespace Aula01Api.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;
        
        public ClientRepository(IConfiguration cofiguration)
        {
            _configuration = cofiguration;
        }
        public List<Client> GetClients()
        {
            var query = "SELECT * FROM Clientes";
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Query<Client>(query).ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error Type {ex.GetType().Name}Message {ex.Message}, Stack Trace{ex.StackTrace}, Target {ex.TargetSite}");
                return null;
            }
            
        }
        public Client GetClient(long id)
        {
            var query = "SELECT * FROM Clientes WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.QuerySingleOrDefault<Client>(query, parameters);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error Type {ex.GetType().Name}Message {ex.Message}, Stack Trace{ex.StackTrace}, Target {ex.TargetSite}");
                return new Client { Cpf = "0", DataNascimento = Convert.ToDateTime(0), Id = 0, Nome = ""};
            }
        }
        public bool InsertClient(Client client)
        {
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @age)";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", client.Cpf);
            parameters.Add("nome", client.Nome);
            parameters.Add("dataNascimento", client.DataNascimento);
            parameters.Add("age", client.Age);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error Type {ex.GetType().Name}Message {ex.Message}, Stack Trace{ex.StackTrace}, Target {ex.TargetSite}");
                return false;
            }

        }

        public bool UpdateClient(Client client, long id)
        {
            var query = "UPDATE Clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            parameters.Add("cpf", client.Cpf);
            parameters.Add("nome", client.Nome);
            parameters.Add("dataNascimento", client.DataNascimento);
            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error Type {ex.GetType().Name}Message {ex.Message}, Stack Trace{ex.StackTrace}, Target {ex.TargetSite}");
                return false;
            }            
        }

        public bool DeleteClient(long id)
        {
            var query = "DELETE from Clientes WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error Type {ex.GetType().Name}Message {ex.Message}, Stack Trace{ex.StackTrace}, Target {ex.TargetSite}");
                return false;
            }
        }

        public Client GetClient(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            try
            {
                using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return conn.QuerySingleOrDefault<Client>(query, parameters);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error Type {ex.GetType().Name}Message {ex.Message}, Stack Trace{ex.StackTrace}, Target {ex.TargetSite}");
                return new Client { Cpf = "0", DataNascimento = Convert.ToDateTime(0), Id = 0, Nome = "" };
            }
        }
    }

}
