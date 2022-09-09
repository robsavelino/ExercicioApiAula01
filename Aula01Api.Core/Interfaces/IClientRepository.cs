using Aula01Api.Core.Model;

namespace Aula01Api.Core.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetClients();
        Client GetClient(long id);
        bool InsertClient(Client client);
        bool UpdateClient(Client client, long id);
        bool DeleteClient(long id);
    }
}
