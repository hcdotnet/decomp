using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class AssetKeyframe {
    [JsonProperty("resourceType")]
    public string ResourceType { get; set; }

    [JsonProperty("resourceVersion")]
    public string ResourceVersion { get; set; }

    [JsonProperty("id")]
    public ResourceLinkTarget Id { get; set; }
}
