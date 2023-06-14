using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmRoomSettings {
    [JsonProperty("inheritRoomSettings")]
    public bool InheritRoomSettings { get; set; }

    [JsonProperty("Width")]
    public int Width { get; set; }

    [JsonProperty("Height")]
    public int Height { get; set; }

    [JsonProperty("persistent")]
    public bool Persistent { get; set; }
}
