using Domain.Entity;
using MediatR;

namespace Application.Queries
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
