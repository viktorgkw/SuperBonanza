using System.Text.Json.Serialization;

namespace Entertainment.Domain.Entities;

public class Joke
{
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }
}