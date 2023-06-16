using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class KeyframeStore<T> {
    [JsonProperty("ResourceType")]
    public string ResourceType { get; set; }

    [JsonProperty("ResourceVersion")]
    public string ResourceVersion { get; set; }

    [JsonProperty("Keyframes")]
    public List<Keyframe<T>> Keyframes { get; set; }
}
