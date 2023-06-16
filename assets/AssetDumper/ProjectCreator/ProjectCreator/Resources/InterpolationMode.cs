using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum InterpolationMode {
    [JsonProperty("None")]
    None,

    [JsonProperty("Linear")]
    Linear,
}
