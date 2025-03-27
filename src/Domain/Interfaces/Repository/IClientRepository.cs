using Domain.Entity;

namespace Domain.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<Client> GetById(Guid id, CancellationToken cancellationToken);
        Task<IList<Client>> GetAll(CancellationToken cancellationToken);
        Task<Client> Save(Client client, CancellationToken cancellationToken);
        Task<Client> Update(Client client, CancellationToken cancellationToken);
        Task<Client> Delete(Guid id, CancellationToken cancellationToken);
    }
}
