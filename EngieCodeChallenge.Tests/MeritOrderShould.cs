using EngieCodeChallenge.ProductionPlan;
using EngieCodeChallenge.ProductionPlan.Dto;
using FluentAssertions;
using Production = EngieCodeChallenge.ProductionPlan.Dto.Production;

namespace EngieCodeChallenge.Tests;

public class MeritOrderShould
{
    [Theory]
    [ClassData(typeof(SuccessfulPayloadsData))]
    public void HandleProvidedPayloads(Payload payload)
    {
        var production = new MeritOrder().Calculate(payload);

        var success = (Result<List<Production>>.Success)production;
        var sum = success.Result.Select(x => x.Produced).Sum();
        sum.Should().Be(payload.Load);
    }

    [Theory]
    [ClassData(typeof(UnsuccessfulPayloadsData))]
    public void NotHandleLoadsThatAreTooHigh(Payload payload)
    {
        var production = new MeritOrder().Calculate(payload);

        var success = (Result<List<Production>>.Failure)production;
        success.Reason
            .Should().NotBeNull()
            .And.Be("Load could not be handled");
    }

    [Fact]
    public void ReturnExactlyLoadAsProductions()
    {
        var (meritOrder, payload) = Setup();

        var production = meritOrder.Calculate(payload);


        var success = (Result<List<Production>>.Success)production;
        var sum = success.Result.Select(x => x.Produced).Sum();
        sum.Should().Be(payload.Load);

        static (MeritOrder meritOrder, Payload payload) Setup()
        {
            var meritOrder1 = new MeritOrder();
            var powerplants = new List<Powerplant>
            {
                new("wind1", FuelType.WindTurbine, 1, 0, 20),
                new("wind2", FuelType.WindTurbine, 1, 0, 190),
                new("wind3", FuelType.WindTurbine, 1, 0, 140),
                new("wind4", FuelType.WindTurbine, 1, 0, 90),
                new("wind5", FuelType.WindTurbine, 1, 0, 120),
                new("wind6", FuelType.WindTurbine, 1, 0, 90)
            };
            var fuels = new Fuels(20, 20, 20, 20);
            var payload1 = new Payload(100, fuels, powerplants);
            return (meritOrder1, payload1);
        }
    }
}