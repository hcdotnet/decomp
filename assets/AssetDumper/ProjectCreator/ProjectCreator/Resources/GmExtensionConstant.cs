using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmExtensionConstant : ResourceBase {
    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("hidden")]
    public bool Hidden { get; set; }
}
