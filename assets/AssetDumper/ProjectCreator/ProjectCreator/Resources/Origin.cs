using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum Origin {
    [JsonProperty("TopLeft")]
    TopLeft,

    [JsonProperty("TopCentre")]
    TopCenter,

    [JsonProperty("TopRight")]
    TopRight,

    [JsonProperty("MiddleLeft")]
    MiddleLeft,

    [JsonProperty("MiddleCentre")]
    MiddleCenter,

    [JsonProperty("MiddleRight")]
    MiddleRight,

    [JsonProperty("BottomLeft")]
    BottomLeft,

    [JsonProperty("BottomCentre")]
    BottomCenter,

    [JsonProperty("BottomRight")]
    BottomRight,

    [JsonProperty("Custom")]
    Custom,
}
