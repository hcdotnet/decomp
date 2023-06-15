using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmProject : ResourceBase {
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

    public static GmProject CreateNew(string name) {
        return new GmProject {
            ResourceType = "GMProject",
            ResourceVersion = "1.7",
            Name = name,
            AudioGroups = new List<GmAudioGroup> {
                new()  {
                    ResourceType = "GMAudioGroup",
                    ResourceVersion = "1.3",
                    Name = "audiogroup_default",
                    Targets = TargetPlatforms.AllPlatforms,
                },
            },
            Config = new GmProjectConfig {
                Children = new List<GmProjectConfig>(),
                Name = "Default",
            },
            DefaultScriptType = DefaultScriptType.None,
            Folders = new List<GmFolder> {
                QuickMakeFolder("Sprites"),
                QuickMakeFolder("Tile Sets"),
                QuickMakeFolder("Sounds"),
                QuickMakeFolder("Paths"),
                QuickMakeFolder("Scripts"),
                QuickMakeFolder("Shaders"),
                QuickMakeFolder("Fonts"),
                QuickMakeFolder("Timelines"),
                QuickMakeFolder("Objects"),
                QuickMakeFolder("Rooms"),
                QuickMakeFolder("Sequences"),
                QuickMakeFolder("Animation Curves"),
                QuickMakeFolder("Notes"),
                QuickMakeFolder("Extensions"),
                QuickMakeFolder("Particle Systems"),
            },
            IncludedFiles = new List<GmIncludedFile>(),
            IsEcma = false,
            LibraryEmitters = new List<ResourceLinkTarget>(),
            Metadata = new Dictionary<string, string> {
                { "IDEVersion", "2023.4.0.84" }, // TODO: necessary? better default?
            },
            Resources = new List<ResourceWeight>(), // todo: do I bother with a default room?
            RoomOrderNodes = new List<GmRoomOrderNode>(), // todo: do I bother with a default room?
            TextureGroups = new List<GmTextureGroup> {
                new() {
                    ResourceType = "GMTextureGroup",
                    ResourceVersion = "1.3",
                    Name = "Default",
                    AutoCrop = true,
                    Border = 2,
                    CompressFormat = "bz2",
                    Directory = "",
                    GroupParent = null,
                    IsScaled = true,
                    LoadType = "default",
                    MipsToGenerate = 0,
                    Targets = TargetPlatforms.AllPlatforms,
                },
            },
        };
    }

    private static GmFolder QuickMakeFolder(string name) {
        return new GmFolder {
            ResourceType = "GMFolder",
            ResourceVersion = "1.0",
            Name = name,
            FolderPath = $"folders/{name}.yy", // TODO: ok default? it's what the IDE uses
        };
    }
}
