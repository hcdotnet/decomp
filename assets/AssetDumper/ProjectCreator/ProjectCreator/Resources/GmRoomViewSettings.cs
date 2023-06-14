using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmRoomViewSettings {
    [JsonProperty("inheritViewSettings")]
    public bool inheritViewSettings { get; set; }

    [JsonProperty("enableViews")]
    public bool enableViews { get; set; }

    [JsonProperty("clearViewBackground")]
    public bool clearViewBackground { get; set; }

    [JsonProperty("clearDisplayBuffer")]
    public bool clearDisplayBuffer { get; set; }
}
