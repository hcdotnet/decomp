using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmTextureGroup : GmBaseGroup {
    [JsonProperty("isScaled")]
    public bool IsScaled { get; set; }

    [JsonProperty("compressFormat")]
    public string CompressFormat { get; set; }

    [JsonProperty("loadType")]
    public string LoadType { get; set; }

    [JsonProperty("directory")]
    public string Directory { get; set; }

    [JsonProperty("autocrop")]
    public bool AutoCrop { get; set; }

    [JsonProperty("border")]
    public int Border { get; set; }

    [JsonProperty("mipsToGenerate")]
    public int MipsToGenerate { get; set; }

    [JsonProperty("groupParent")]
    public ResourceLinkTarget GroupParent { get; set; }
}
