using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectCreator.ProjectCreator.Resources;

namespace ProjectCreator.ProjectCreator; 

public sealed class GmResourceOrderFile {
    [JsonProperty("ResourceOrderSettings")]
    public List<NameAndPathOrder> ResourceOrderSettings { get; set; }

    [JsonProperty("FolderOrderSettings")]
    public List<NameAndPathOrder> FolderOrderSettings { get; set; }
}
