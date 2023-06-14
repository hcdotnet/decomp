using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources; 

public class ResourceLinkTarget {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("path")]
    public string Path { get; set; }
}
