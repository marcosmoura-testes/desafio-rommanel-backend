using Domain.Entity;
using Domain.Interfaces.Repository;
using MongoDB.Driver;

namespace Infra.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly MongoDbContext _mongoDbContext;

        public ClientRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        // Implementação do método Delete
        public async Task<Client> Delete(Guid id, CancellationToken cancellationToken)
        {
            var clientCollection = _mongoDbContext.GetCollection<Client>(typeof(Client).Name);

            // Deleta o cliente com base no ID
            var result = await clientCollection.DeleteOneAsync(c => c.Id == id, cancellationToken);

            if (result.DeletedCount > 0)
            {
                // Retorna um cliente deletado (caso necessário)
                return new Client(id);
            }

            return null; // Ou lance uma exceção se preferir
        }

        // Implementação do método GetAll
        public async Task<IList<Client>> GetAll(CancellationToken cancellationToken)
        {
            var clientCollection = _mongoDbContext.GetCollection<Client>(typeof(Client).Name);

            // Obtém todos os clientes
            var clients = await clientCollection.Find(_ => true).ToListAsync(cancellationToken);

            return clients;
        }

        // Implementação do método GetById
        public async Task<Client> GetById(Guid id, CancellationToken cancellationToken)
        {
            var clientCollection = _mongoDbContext.GetCollection<Client>(typeof(Client).Name);

            // Obtém o cliente pelo ID
            var client = await clientCollection.Find(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);

            return client;
        }

        // Implementação do método Save
        public async Task<Client> Save(Client client, CancellationToken cancellationToken)
        {
            var clientCollection = _mongoDbContext.GetCollection<Client>(typeof(Client).Name);

            // Insere um novo cliente
            await clientCollection.InsertOneAsync(client, cancellationToken: cancellationToken);

            return client;
        }

        // Implementação do método Update
        public async Task<Client> Update(Client client, CancellationToken cancellationToken)
        {
            var clientCollection = _mongoDbContext.GetCollection<Client>(typeof(Client).Name);

            // Atualiza o cliente
            var result = await clientCollection.ReplaceOneAsync(c => c.Id == client.Id, client, cancellationToken: cancellationToken);

            if (result.MatchedCount > 0)
            {
                return client; // Retorna o cliente atualizado
            }

            return null; // Ou lance uma exceção, dependendo de como você quer tratar
        }
    }
}
