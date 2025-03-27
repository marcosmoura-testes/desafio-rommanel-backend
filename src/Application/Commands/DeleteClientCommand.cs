using Domain.Entity;
using MediatR;

namespace Application.Commands
{
    public class DeleteClientCommand : IRequest<Client>
    {
        public Guid Id { get; set; }

        public DeleteClientCommand(Guid id)
        {
            Id = id;
        }
    }
}
