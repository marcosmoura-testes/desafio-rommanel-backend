using Application.Queries;
using Domain.Entity;
using Domain.UoW;
using MediatR;

namespace Application.QueryHandlers
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IList<Client>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _unitOfWork.ClientRepository.GetAll(cancellationToken);
            return clients;
        }
    }
}
