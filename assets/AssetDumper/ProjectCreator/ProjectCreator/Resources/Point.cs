using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class Point {
    [JsonProperty("x")]
    public float X { get; set; }

    [JsonProperty("y")]
    public float Y { get; set; }
}
