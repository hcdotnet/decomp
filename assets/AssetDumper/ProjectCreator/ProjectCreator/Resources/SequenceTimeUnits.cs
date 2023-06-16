using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum SequenceTimeUnits {
    [JsonProperty("Time")]
    Time,

    [JsonProperty("Frames")]
    Frames,
}
