using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EngieCodeChallenge.ProductionPlan.Dto;

public record Fuels(
    [property: JsonPropertyName("gas(euro/MWh)"), Required]
    decimal GasEuroMWh,
    [property: JsonPropertyName("kerosine(euro/MWh)"), Required]
    decimal KerosineEuroMWh,
    [property: JsonPropertyName("co2(euro/ton)"), Required]
    decimal Co2EuroTon,
    [property: JsonPropertyName("wind(%)"), Required]
    decimal Wind
);