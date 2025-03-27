using Application.Commands;
using Domain.Entity;
using Domain.UoW;
using MediatR;

namespace Application.CommandHandlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetById(request.Id, cancellationToken);
            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }

            await _unitOfWork.ClientRepository.Delete(request.Id, cancellationToken);
            return client;
        }
    }
}
