using Aula01Api.Core.Interfaces;
using Aula01Api.Core.Model;

namespace Aula01Api.Core.Services
{
    public class ClientService : IClientService
    {
        public IClientRepository _clientsRepository;
        public ClientService(IClientRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
        public List<Client> GetClients()
        {
            return _clientsRepository.GetClients();
        }
        public Client GetClient(long id)
        {
            return _clientsRepository.GetClient(id);
        }
        public bool InsertClient(Client client)
        {
            return _clientsRepository.InsertClient(client);
        }
        public bool UpdateClient(Client client, long id)
        {
            return _clientsRepository.UpdateClient(client, id);
        }
        public bool DeleteClient(long id)
        {
            return _clientsRepository.DeleteClient(id);
        }

        public Client GetClient(string cpf)
        {
            return _clientsRepository.GetClient(cpf);
        }
    }
}
