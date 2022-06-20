using System.Text.Json.Serialization;

namespace EngieCodeChallenge.ProductionPlan.Dto;

public record Production(
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("p")]
    decimal Produced
);