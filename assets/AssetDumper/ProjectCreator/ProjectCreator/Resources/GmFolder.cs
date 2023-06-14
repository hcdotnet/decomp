using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources; 

public class GmFolder {
    [JsonProperty("folderPath")]
    public string FolderPath { get; set; }
}
