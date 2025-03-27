using Domain.Interfaces.Repository;
using Domain.UoW;
using Infra.Repository;

namespace Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoDbContext _mongoDbContext;

        public UnitOfWork(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }


        private IClientRepository _clientRepository;
        public IClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_mongoDbContext);
                }

                return _clientRepository;
            }
        }
    }
}
