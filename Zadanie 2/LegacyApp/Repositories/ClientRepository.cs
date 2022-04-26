using LegacyApp.Models;

namespace LegacyApp.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public ClientRepository()
        {
        }

        public Client GetById(int clientId)
        {
            //Fetching the data...
            return new Client
            {
                ClientId = clientId,
                Name = clientId switch
                {
                    1 => "VeryImportantClient",
                    2 => "ImportantClient",
                    _ => null
                }
            };
        }
    }
}