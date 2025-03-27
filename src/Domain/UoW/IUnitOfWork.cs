using Domain.Interfaces.Repository;

namespace Domain.UoW
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
    }
}
