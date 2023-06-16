using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum LayerBlendType {
    [JsonProperty("Normal")]
    Normal,

    [JsonProperty("Add")]
    Add,

    [JsonProperty("Subtract")]
    Subtract,

    [JsonProperty("Multiply")]
    Multiply,
}
