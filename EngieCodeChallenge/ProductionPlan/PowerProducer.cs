using EngieCodeChallenge.ProductionPlan.Dto;

namespace EngieCodeChallenge.ProductionPlan;

public class PowerProducer
{
    public decimal Produced { get; private set; }

    public decimal MaximumProduction { get; init; }
    public decimal EurMwh { get; init; }

    public decimal ActivationCostEur
        => Pmin * EurMwh;

    public decimal MaxCostEur
        => MaximumProduction * EurMwh;

    public bool IsFree
        => EurMwh == 0m && Pmin == 0m;

    public decimal ProducedOverPmin
        => Math.Clamp(Produced - Pmin, 0m, MaximumProduction - Pmin);

    public bool CanBeActivatedFor(decimal load)
        => Pmin <= Produced + load;

    public bool CanHandleTheLoad(decimal load)
        => CanBeActivatedFor(load) && LoadDoesNotExceedCapacity(load);

    public bool LoadDoesNotExceedCapacity(decimal load)
        => Produced + load < MaximumProduction;


    public void HandleLoad(ref decimal remainingLoad, out decimal produced)
    {
        produced = CalculateHowMuchCanBeProducedForDemand(remainingLoad);
        Produced += produced;
        remainingLoad -= produced;
    }

    private decimal CalculateHowMuchCanBeProducedForDemand(decimal load)
    {
        var expectedProduction = Produced + load;
        if (expectedProduction < Pmin)
            return 0;
        if (expectedProduction > MaximumProduction)
            return load - (expectedProduction - MaximumProduction);
        return load;
    }
    
    public string Name { get; init; }
    public FuelType Type { get; init; }
    public decimal Efficiency { get; init; }
    public decimal Pmin { get; init; }

    public void RestrictProductionToZeroOrPmin()
        => Produced = Math.Clamp(Produced, 0m, Pmin);
}