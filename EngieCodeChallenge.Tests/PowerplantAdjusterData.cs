using EngieCodeChallenge.ProductionPlan;
using EngieCodeChallenge.ProductionPlan.Dto;

namespace EngieCodeChallenge.Tests;

public class PowerplantAdjusterData : TheoryData<Powerplant, Fuels, PowerProducer>
{
    public PowerplantAdjusterData()
    {
        AddWind1();
        AddGas1();
        AddTurbo1();
    }

    private static readonly Fuels Fuels1 = new(10, 50, 100, 50);
    private static readonly Powerplant _empty = new("", FuelType.WindTurbine, 0, 0, 0);
    

    private void AddWind1()
        => Add(
            _empty with
            {
                Pmin = 0,
                Pmax = 100,
                Efficiency = 1,
                Name = "wind1",
                Type = FuelType.WindTurbine
            },
            Fuels1,
            new PowerProducer
            {
                Pmin = 0,
                MaximumProduction = 50,
                Efficiency = 1,
                Name = "wind1",
                Type = FuelType.WindTurbine,
                EurMwh = 0
            });

    private void AddGas1()
        => Add(
            _empty with
            {
                Pmin = 100,
                Pmax = 200,
                Efficiency = 0.5m,
                Name = "gas1",
                Type = FuelType.GasFired
            },
            Fuels1,
            new PowerProducer
            {
                EurMwh = 50,
                Pmin = 100,
                MaximumProduction = 200,
                Efficiency = 0.5m,
                Name = "gas1",
                Type = FuelType.GasFired
            });

    private void AddTurbo1()
        => Add(
            _empty with
            {
                Pmin = 100,
                Pmax = 200,
                Efficiency = 0.5m,
                Name = "turbo1",
                Type = FuelType.TurboJet
            },
            Fuels1,
            new PowerProducer
            {
                EurMwh = 100,
                Pmin = 100,
                MaximumProduction = 200,
                Efficiency = 0.5m,
                Name = "turbo1",
                Type = FuelType.TurboJet
            });
}