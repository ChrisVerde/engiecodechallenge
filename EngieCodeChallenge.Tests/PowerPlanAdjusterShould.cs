using EngieCodeChallenge.ProductionPlan;
using EngieCodeChallenge.ProductionPlan.Dto;
using FluentAssertions;

namespace EngieCodeChallenge.Tests;

public class PowerPlanAdjusterShould
{
    [Theory]
    [ClassData(typeof(PowerplantAdjusterData))]
    public void PropagatesBasePowerplantInfo(Powerplant powerplant, Fuels fuels, PowerProducer expected)
    {
        var adjuster = new PowerplantAdjuster();

        var result = adjuster.Adjust(powerplant, fuels).First();

        result.Efficiency.Should().Be(expected.Efficiency);
        result.Pmin.Should().Be(expected.Pmin);
        result.MaximumProduction.Should().Be(expected.MaximumProduction);
        result.Name.Should().Be(expected.Name);
        result.Type.Should().Be(expected.Type);
        result.EurMwh.Should().Be(expected.EurMwh);
    }
}