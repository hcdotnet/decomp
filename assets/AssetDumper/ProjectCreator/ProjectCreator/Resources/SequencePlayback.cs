using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum SequencePlayback {
    [JsonProperty("None")]
    None = -1,

    [JsonProperty("Normal")]
    Normal,

    [JsonProperty("Loop")]
    Loop,

    [JsonProperty("PingPong")]
    PingPong,
}
