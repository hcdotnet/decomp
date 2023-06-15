using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmExtensionFile : ResourceBase {
    [JsonProperty("filename")]
    public string FileName { get; set; }

    [JsonProperty("origname")]
    public string OrigName { get; set; }

    [JsonProperty("init")]
    public string Init { get; set; }

    [JsonProperty("final")]
    public string Final { get; set; }

    [JsonProperty("kind")]
    public int Kind { get; set; }

    [JsonProperty("uncompress")]
    public bool Uncompress { get; set; }

    [JsonProperty("functions")]
    public List<GmExtensionFunction> Functions { get; set; }

    [JsonProperty("constants")]
    public List<GmExtensionConstant> Constants { get; set; }

    [JsonProperty("ProxyFiles")]
    public List<GmProxyFile> ProxyFiles { get; set; }

    [JsonProperty("copyToTargets")]
    public long CopyToTargets { get; set; }

    [JsonProperty("usesRunnerInterface")]
    public bool UsesRunnerInterface { get; set; }

    [JsonProperty("order")]
    public List<ResourceLinkTarget> Order { get; set; }
}
