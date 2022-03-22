using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Users;

namespace WebApi.Features;

public static class Endpoints
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/user/{id}", (int id, [FromServices] IMediator mediator) => Send(mediator, new GetUser.Query(id)))
            .Produces<GetUser.Response>()
            .WithName("GetUser");
    }

    private static async Task<IResult> Send<TResponse>(IMediator mediator, IRequest<TResponse> request)
    {
        return Results.Json(await mediator.Send(request));
    }
}
