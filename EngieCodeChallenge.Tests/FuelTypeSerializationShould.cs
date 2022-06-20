using System.Text.Json;
using EngieCodeChallenge.ProductionPlan.Dto;
using FluentAssertions;

namespace EngieCodeChallenge.Tests;

public class FuelTypeSerializationShould
{
    [Theory]
    [InlineData("\"magic\"")]
    [InlineData("\"alchemy\"")]
    private void UnknownTypesAreMappedToUnknown(string unknownEnergySource)
    {
        var unknown = JsonSerializer.Deserialize<FuelType>(unknownEnergySource);
        unknown.Should().Be(FuelType.Unknown);
    }

    [Fact]
    private void DeserializeAllKnownFuelTypes()
    {
        var windType = JsonSerializer.Deserialize<FuelType>("\"windturbine\"");
        windType.Should().Be(FuelType.WindTurbine);

        var turboType = JsonSerializer.Deserialize<FuelType>("\"turbojet\"");
        turboType.Should().Be(FuelType.TurboJet);

        var gasType = JsonSerializer.Deserialize<FuelType>("\"gasfired\"");
        gasType.Should().Be(FuelType.GasFired);
    }
}