using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class NameAndPathOrder {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("path")]
    public string Path { get; set; }

    [JsonProperty("order")]
    public int Order { get; set; }
}
