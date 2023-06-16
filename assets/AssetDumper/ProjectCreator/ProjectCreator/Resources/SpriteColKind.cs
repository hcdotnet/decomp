using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum SpriteColKind {
    [JsonProperty("Rectangle")]
    Rectangle = 1,

    [JsonProperty("Ellipse")]
    Ellipse = 2,

    [JsonProperty("Diamond")]
    Diamond = 3,

    [JsonProperty("Precise")]
    Precise = 0,

    [JsonProperty("PrecisePerFrame")]
    PrecisePerFrame = 4,

    [JsonProperty("RectangleRotation")]
    RectangleRotation = 5,
}
