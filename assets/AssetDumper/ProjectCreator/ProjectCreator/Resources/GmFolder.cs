using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources; 

public class GmFolder : ResourceBase {
    [JsonProperty("folderPath")]
    public string FolderPath { get; set; }
}
