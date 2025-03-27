using Domain.Entity;
using MediatR;

namespace Application.Queries
{
    public class GetAllClientsQuery : IRequest<IList<Client>>
    {
    }
}
