using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum GmSoundBitDepth {
    [JsonProperty("_8bit")]
    _8bit,

    [JsonProperty("_16bit")]
    _16bit,
}
