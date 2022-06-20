using EngieCodeChallenge.ProductionPlan.Dto;

namespace EngieCodeChallenge.ProductionPlan;

public class PowerplantAdjuster
{
    public const string TypeIsUnknown = "Type is unknown";

    public Result<PowerProducer> Adjust(Powerplant powerplant, Fuels fuels)
        => powerplant.Type switch
        {
            FuelType.GasFired => AdjustGasPowerplant(powerplant, fuels),
            FuelType.WindTurbine => AdjustWindPowerplant(powerplant, fuels),
            FuelType.TurboJet => AdjustTurboJetPowerplant(powerplant, fuels),
            _ => Result.Failure<PowerProducer>(TypeIsUnknown)
        };

    private static Result<PowerProducer> AdjustTurboJetPowerplant(Powerplant powerplant, Fuels fuels)
        => Result.Success(new PowerProducer
        {
            Name = powerplant.Name,
            Type = powerplant.Type,
            Efficiency = powerplant.Efficiency,
            Pmin = powerplant.Pmin,
            MaximumProduction = powerplant.Pmax,
            EurMwh = fuels.KerosineEuroMWh * 1 / powerplant.Efficiency
        });

    private static Result<PowerProducer> AdjustWindPowerplant(Powerplant powerplant, Fuels fuels)
        => Result.Success(new PowerProducer
        {
            Name = powerplant.Name,
            Type = powerplant.Type,
            Efficiency = powerplant.Efficiency,
            Pmin = powerplant.Pmin,
            MaximumProduction = powerplant.Pmax * (fuels.Wind / 100),
            EurMwh = 0
        });

    private static Result<PowerProducer> AdjustGasPowerplant(Powerplant powerplant, Fuels fuels)
        => Result.Success(new PowerProducer
        {
            Name = powerplant.Name,
            Type = powerplant.Type,
            Efficiency = powerplant.Efficiency,
            Pmin = powerplant.Pmin,
            MaximumProduction = powerplant.Pmax,
            EurMwh = fuels.GasEuroMWh / powerplant.Efficiency + 0.3m * fuels.Co2EuroTon
        });
}