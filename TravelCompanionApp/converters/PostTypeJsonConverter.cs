using System.Text.Json;
using System.Text.Json.Serialization;
using TravelCompanionApp.models;

namespace TravelCompanionApp.converters;

public class PostTypeJsonConverter : JsonConverter<PostType>
{
    public override PostType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Enum.Parse<PostType>(reader.GetString(), ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, PostType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}