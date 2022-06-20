using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EngieCodeChallenge.ProductionPlan.Dto;

public record Powerplant(
    [property: JsonPropertyName("name"), Required]
    string Name,
    [property: JsonPropertyName("type"), Required, EnumDataType(typeof(FuelType))]
    FuelType Type,
    [property: JsonPropertyName("efficiency"), Required]
    decimal Efficiency,
    [property: JsonPropertyName("pmin"), Required]
    decimal Pmin,
    [property: JsonPropertyName("pmax"), Required]
    decimal Pmax
);

[JsonConverter(typeof(FuelTypeConverter))]
public enum FuelType
{
    Unknown,
    WindTurbine,
    GasFired,
    TurboJet
}