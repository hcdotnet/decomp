using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public abstract class KeyframeBase {
    [JsonProperty("resourceType")]
    public string ResourceType { get; set; }

    [JsonProperty("resourceVersion")]
    public string ResourceVersion { get; set; }

    [JsonProperty("events")]
    public List<string> Events { get; set; }
}
