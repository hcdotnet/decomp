using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmEvent : ResourceBase {
    [JsonProperty("isDnd")]
    public bool IsDnd { get; set; }

    [JsonProperty("eventNum")]
    public int EventNum { get; set; }

    [JsonProperty("eventType")]
    public int EventType { get; set; }

    [JsonProperty("collisionObjectId")]
    public ResourceLinkTarget CollisionObjectId { get; set; }
}
