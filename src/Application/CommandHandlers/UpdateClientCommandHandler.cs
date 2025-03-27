using Application.Commands;
using Domain.Entity;
using Domain.UoW;
using MediatR;

namespace Application.CommandHandlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetById(request.Id, cancellationToken);
            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }

            client = new Client(request.Id, request.FullName, request.CpfCnpj, request.BirthDate, request.Phone, request.Email,
                request.StateRegistration, request.IsStateRegistrationExempt, new ClientAddress(request.Address.Street, request.Address.Number,
                request.Address.Neighborhood, request.Address.City, request.Address.State, request.Address.ZipCode));

            var updatedClient = await _unitOfWork.ClientRepository.Update(client, cancellationToken);
            return updatedClient;
        }
    }
}
