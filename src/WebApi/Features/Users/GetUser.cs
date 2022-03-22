using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;

namespace WebApi.Features.Users;

public static class GetUser
{
    public record Query(int Id) : IRequest<Response>;

    public record Response(User User);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IAppDbContext _dbContext;

        public Handler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var person = await _dbContext.Users.FirstAsync(x => x.Id == request.Id, cancellationToken);
            return new Response(person);
        }
    }
}
