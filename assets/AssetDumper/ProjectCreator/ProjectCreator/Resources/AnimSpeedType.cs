using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum AnimSpeedType {
    [JsonProperty("FramesPerSecond")]
    FramesPerSecond,

    [JsonProperty("FramesPerGameFrame")]
    FramesPerGameFrame,
}
