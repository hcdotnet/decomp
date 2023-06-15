using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum ExtensionOptionType {
    [JsonProperty("Boolean")]
    Boolean,

    [JsonProperty("Number")]
    Number,

    [JsonProperty("String")]
    String,

    [JsonProperty("FilePath")]
    FilePath,

    [JsonProperty("FolderPath")]
    FolderPath,

    [JsonProperty("Label")]
    Label,

    [JsonProperty("List")]
    List,
}
