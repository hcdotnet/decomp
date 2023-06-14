using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectCreator.ProjectCreator.Resources;

namespace ProjectCreator.ProjectCreator;

public sealed class GmProject {
    public class ResourceWeight {
        [JsonProperty("id")]
        public ResourceLinkTarget Id { get; set; }
    }

    [JsonProperty("resources")]
    public List<ResourceWeight> Resources { get; set; }

    [JsonProperty("isDnDProject")]
    public bool IsDnDProject { get; set; }

    [JsonProperty("defaultScriptType")]
    public DefaultScriptType DefaultScriptType { get; set; }

    [JsonProperty("isEcma")]
    public bool IsEcma { get; set; }

    [JsonProperty("Config")]
    public GmProjectConfig Config { get; set; }

    [JsonProperty("RoomOrderNodes")]
    public List<GmRoomOrderNode> RoomOrderNodes { get; set; }

    [JsonProperty("Folders")]
    public List<GmFolder> Folders { get; set; }

    [JsonProperty("AudioGroups")]
    public List<GmAudioGroup> AudioGroups { get; set; }

    [JsonProperty("TextureGroups")]
    public List<GmTextureGroup> TextureGroups { get; set; }

    [JsonProperty("IncludedFiles")]
    public List<GmIncludedFile> IncludedFiles { get; set; }

    [JsonProperty("LibraryEmitters")]
    public List<ResourceLinkTarget> LibraryEmitters { get; set; }

    [JsonProperty("MetaData")]
    public Dictionary<string, string> Metadata { get; set; }
}
