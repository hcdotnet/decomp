using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmOverriddenProperty : ResourceBase {
    [JsonProperty("propertyId")]
    public ResourceLinkTarget PropertyId { get; set; }

    [JsonProperty("objectId")]
    public ResourceLinkTarget ObjectId { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
}
