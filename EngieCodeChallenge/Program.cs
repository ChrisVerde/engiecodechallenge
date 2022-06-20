using System.Net;
using EngieCodeChallenge.ProductionPlan;
using EngieCodeChallenge.ProductionPlan.Dto;
using Microsoft.AspNetCore.Mvc;
using Production = EngieCodeChallenge.ProductionPlan.Dto.Production;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSingleton<MeritOrder>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapPost(
    "/productionplan",
    (MeritOrder meritOrder, [FromBody] Payload payload)
        => meritOrder.Calculate(payload) switch
        {
            Result<List<Production>>.Success(var productions)
                => Results.Ok(productions),
            Result<List<Production>>.Failure(var reason)
                => Results.UnprocessableEntity(reason),
            _ 
                => Results.StatusCode((int)HttpStatusCode.InternalServerError)
        }
);
app.Run();