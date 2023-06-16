using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum BboxMode {
    [JsonProperty("Automatic")]
    Automatic,

    [JsonProperty("FullImage")]
    FullImage,

    [JsonProperty("Manual")]
    Manual,
}
