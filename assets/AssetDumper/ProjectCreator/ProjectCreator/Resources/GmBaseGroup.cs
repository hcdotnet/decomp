using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources; 

public class GmBaseGroup : ResourceBase {
    [JsonProperty("targets")]
    public TargetPlatforms Targets { get; set; }
}
