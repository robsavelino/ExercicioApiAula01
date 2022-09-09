using Aula01Api.Core.Model;

namespace Aula01Api.Core.Interfaces
{
    public interface IClientService
    {
        List<Client> GetClients();
        Client GetClient(long id);
        Client GetClient(string cpf);
        bool InsertClient(Client client);
        bool UpdateClient(Client client, long id);
        bool DeleteClient(long id);
    }
}
