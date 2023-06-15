using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmExtensionFrameworkEntry : ResourceBase {
    [JsonProperty("weakReference")]
    public bool WeakReference { get; set; }

    [JsonProperty("embed")]
    public int Embed { get; set; }
}
