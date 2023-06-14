using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmProjectConfig {
    [JsonProperty("name")]
    public string Name { get; set; }

    // lol what's the point
    [JsonProperty("children")]
    public List<GmProjectConfig> Children { get; set; }
}
