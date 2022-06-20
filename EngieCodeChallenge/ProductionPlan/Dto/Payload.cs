using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EngieCodeChallenge.ProductionPlan.Dto;

public record Payload(
    [property: JsonPropertyName("load"), Required, Range(0, int.MaxValue)]
    decimal Load,
    [property: JsonPropertyName("fuels"), Required]
    Fuels Fuels,
    [property: JsonPropertyName("powerplants"), Required, MinLength(1)]
    IReadOnlyList<Powerplant> Powerplants
);