using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum GmConversionMode {
    [JsonProperty("Automatic")]
    Automatic,

    [JsonProperty("Required")]
    Required,
}
