using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum TrackTraits {
    [JsonProperty("None")]
    None = 0,

    [JsonProperty("ChildrenShouldIgnoreOrigin")]
    ChildrenShouldIgnoreOrigin = 1,
}
