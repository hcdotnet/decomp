using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmIncludedFile : ResourceBase {
    [JsonProperty("CopyToMask")]
    public long CopyToMask { get; set; }

    [JsonProperty("filePath")]
    public string FilePath { get; set; }
}
