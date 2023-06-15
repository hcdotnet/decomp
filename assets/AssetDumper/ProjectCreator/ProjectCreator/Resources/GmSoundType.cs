using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum GmSoundType {
    [JsonProperty("Mono")]
    Mono,

    [JsonProperty("Stereo")]
    Stereo,

    [JsonProperty("_3D")]
    _3D,
}
