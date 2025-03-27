using Application.Queries;
using Domain.Entity;
using Domain.UoW;
using MediatR;

namespace Application.QueryHandlers
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            // Busca o cliente pelo ID
            var client = await _unitOfWork.ClientRepository.GetById(request.Id, cancellationToken);
            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }

            return client;
        }
    }
}
