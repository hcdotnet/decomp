using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmProxyFile : ResourceBase {
    [JsonProperty("TargetMask")]
    public long TargetMask { get; set; }
}
