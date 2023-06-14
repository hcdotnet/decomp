using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public abstract class ResourceBase {
    public Dictionary<string, Dictionary<string, string>> ConfigValues { get; set; }

    [JsonProperty("resourceType")]
    public string ResourceType { get; set; }

    [JsonProperty("resourceVersion")]
    public string ResourceVersion { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("parent")]
    public ResourceLinkTarget Parent { get; set; }
}
