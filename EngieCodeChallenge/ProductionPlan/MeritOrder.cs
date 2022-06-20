using EngieCodeChallenge.ProductionPlan.Dto;
using static EngieCodeChallenge.ProductionPlan.Result;

namespace EngieCodeChallenge.ProductionPlan;

public class MeritOrder
{
    public const string LoadCouldNotBeHandled = "Load could not be handled";

    public Result<List<Production>> Calculate(Payload payload)
    {
        try
        {
            var powerplantAdjuster = new PowerplantAdjuster();
            var adjustedPowerplants = payload.Powerplants
                .SelectMany(x => powerplantAdjuster.Adjust(x, payload.Fuels))
                .OrderBy(x => x.EurMwh)
                .ToList();

            var remainingLoad = payload.Load;
            var activated = new List<PowerProducer>();
            foreach (var adjustedPowerplant in adjustedPowerplants)
            {
                if (remainingLoad <= 0)
                    break;

                if (adjustedPowerplant.CanBeActivatedFor(remainingLoad))
                {
                    adjustedPowerplant.HandleLoad(ref remainingLoad, out _);
                    activated.Add(adjustedPowerplant);
                }
                else
                {
                    var exceeding = activated
                        .Select(x => x.ProducedOverPmin)
                        .Sum();

                    foreach (var previouslyActivated in activated)
                        previouslyActivated.RestrictProductionToZeroOrPmin();

                    remainingLoad += exceeding;

                    if (adjustedPowerplant.CanBeActivatedFor(remainingLoad))
                    {
                        adjustedPowerplant.HandleLoad(ref remainingLoad, out _);
                        activated.Add(adjustedPowerplant);
                    }

                    foreach (var previouslyActivated in activated)
                        previouslyActivated.HandleLoad(ref remainingLoad, out _);
                }
            }

            if (remainingLoad > 0)
                throw new ArgumentException(LoadCouldNotBeHandled);

            var productions = activated
                .Select(x => new Production(x.Name, x.Produced))
                .ToList();

            return Success(productions);
        }
        catch (Exception e)
        {
            return Failure<List<Production>>(e.Message);
        }
    }
}