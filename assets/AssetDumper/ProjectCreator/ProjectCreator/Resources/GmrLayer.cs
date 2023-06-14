using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmrLayer : ResourceBase {
    [JsonProperty("visible")]
    public bool Visible { get; set; }

    [JsonProperty("depth")]
    public int Depth { get; set; }

    [JsonProperty("userdefinedDepth")]
    public bool UserDefinedDepth { get; set; }

    [JsonProperty("inheritLayerDepth")]
    public bool InheritLayerDepth { get; set; }

    [JsonProperty("inheritLayerSettings")]
    public bool InheritLayerSettings { get; set; }

    [JsonProperty("inheritVisibility")]
    public bool InheritVisibility { get; set; }

    [JsonProperty("inheritSubLayers")]
    public bool InheritSubLayers { get; set; }

    [JsonProperty("gridX")]
    public int GridX { get; set; }

    [JsonProperty("gridY")]
    public int GridY { get; set; }

    [JsonProperty("layers")]
    public List<GmrLayer> Layers { get; set; }

    [JsonProperty("hierarchyFrozen")]
    public bool HierarchyFrozen { get; set; }

    [JsonProperty("effectEnabled")]
    public bool EffectEnabled { get; set; }

    [JsonProperty("effectType")]
    public string EffectType { get; set; }

    [JsonProperty("properties")]
    public List<GmEffectProp> Properties { get; set; }
}
