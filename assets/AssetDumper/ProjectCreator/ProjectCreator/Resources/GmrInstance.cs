using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmrInstance : GmrItem {
    [JsonProperty("properties")]
    public List<GmOverriddenProperty> Properties { get; set; }

    [JsonProperty("isDnd")]
    public bool IsDnd { get; set; }

    [JsonProperty("objectId")]
    public ResourceLinkTarget ObjectId { get; set; }

    [JsonProperty("inheritCode")]
    public bool InheritCode { get; set; }

    [JsonProperty("hasCreationCode")]
    public bool HasCreationCode { get; set; }

    [JsonProperty("colour")]
    public uint Color { get; set; }

    [JsonProperty("rotation")]
    public float Rotation { get; set; }

    [JsonProperty("scaleX")]
    public float ScaleX { get; set; }

    [JsonProperty("scaleY")]
    public float ScaleY { get; set; }

    [JsonProperty("imageIndex")]
    public int ImageIndex { get; set; }

    [JsonProperty("imageSpeed")]
    public float ImageSpeed { get; set; }
}
