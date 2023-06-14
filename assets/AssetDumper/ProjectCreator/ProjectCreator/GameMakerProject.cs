using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectCreator.DumpedAssetHandler;

namespace ProjectCreator.ProjectSystem;

public sealed class GameMakerProject {
    [JsonProperty("resourceType")]
    public ResourceType ResourceType { get; set; } = ResourceType.GmProject;

    [JsonProperty("resourceVersion")]
    public string ResourceVersion { get; set; } = "1.7";

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("AudioGroups")]
    public List<AudioGroup> AudioGroups { get; set; } = new ();

    [JsonProperty("configs")]
    public Configs Configs { get; set; } = new();

    [JsonProperty("defaultScriptType")]
    public int DefaultScriptType { get; set; } = 0;

    [JsonProperty("Folders")]
    public List<Folder> Folders { get; set; } = new();

    // TODO
    public List<object> IncludedFiles { get; set; } = new();

    public bool IsEcma { get; set; } = false;

    // TODO
    public List<object> LibraryEmitters { get; set; } = new();

    // TODO
    [JsonProperty("MetaData")]
    public Metadata Metadata { get; set; } = new();

    public List<Resource> Resources { get; set; } = new();

    public GameMakerProject(string name) {
        Name = name;
    }

    public void ImportAssetRoot(AssetRoot root) { }

    public void WriteToDirectory(string directory) { }
}
