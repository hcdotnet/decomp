using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmrItem {
    [JsonProperty("inheritedItemId")]
    public ResourceLinkTarget InheritedItemId { get; set; }

    [JsonProperty("frozen")]
    public bool Frozen { get; set; }

    [JsonProperty("ignore")]
    public bool Ignore { get; set; }

    [JsonProperty("inheritItemSettings")]
    public bool InheritItemSettings { get; set; }

    [JsonProperty("x")]
    public float X { get; set; }

    [JsonProperty("y")]
    public float Y { get; set; }
}
