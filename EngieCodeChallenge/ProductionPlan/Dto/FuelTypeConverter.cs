using System.Text.Json;
using System.Text.Json.Serialization;

namespace EngieCodeChallenge.ProductionPlan.Dto;

internal class FuelTypeConverter : JsonConverter<FuelType>
{
    public override FuelType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
        => reader.GetString() switch
        {
            "windturbine" => FuelType.WindTurbine,
            "gasfired" => FuelType.GasFired,
            "turbojet" => FuelType.TurboJet,
            _ => FuelType.Unknown
        };

    public override void Write(Utf8JsonWriter writer, FuelType value, JsonSerializerOptions options)
        => writer.WriteStringValue(value switch
        {
            FuelType.WindTurbine => "windturbine",
            FuelType.TurboJet => "turbojet",
            FuelType.GasFired => "gasfired",
            _ => null
        });
}