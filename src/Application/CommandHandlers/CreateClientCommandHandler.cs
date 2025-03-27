using Application.Commands;
using Domain.Entity;
using Domain.UoW;
using MediatR;

namespace Application.CommandHandlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.FullName, request.CpfCnpj, request.BirthDate, request.Phone, request.Email,
                request.StateRegistration, request.IsStateRegistrationExempt, new ClientAddress(request.Address.Street, request.Address.Number,
                request.Address.Neighborhood, request.Address.City, request.Address.State, request.Address.ZipCode));

            var savedClient = await _unitOfWork.ClientRepository.Save(client, cancellationToken);
            return savedClient;
        }
    }
}
