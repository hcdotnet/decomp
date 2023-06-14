using Newtonsoft.Json;

namespace ProjectCreator.ProjectSystem;

public enum ResourceType {
    [JsonProperty("GMProject")]
    GmProject,

    [JsonProperty("GMAudioGroup")]
    GmAudioGroup,

    [JsonProperty("GMFolder")]
    GmFolder,
}
