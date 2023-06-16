using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmImageLayer : ResourceBase {
    [JsonProperty("visible")]
    public bool Visible { get; set; }

    [JsonProperty("isLocked")]
    public bool IsLocked { get; set; }

    [JsonProperty("blendMode")]
    public LayerBlendType BlendMode { get; set; }

    [JsonProperty("opacity")]
    public float Opacity { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }
}
