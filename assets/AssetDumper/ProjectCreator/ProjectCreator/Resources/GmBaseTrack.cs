using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmBaseTrack : ResourceBase {
    [JsonProperty("trackColour")]
    public uint TrackColor { get; set; }

    [JsonProperty("inheritsTrackColour")]
    public bool InheritsTrackColor { get; set; }

    [JsonProperty("builtinName")]
    public BuiltinTrack BuiltinName { get; set; }

    [JsonProperty("traits")]
    public TrackTraits Traits { get; set; }

    [JsonProperty("interpolation")]
    public InterpolationMode Interpolation { get; set; }

    [JsonProperty("tracks")]
    public List<GmBaseTrack> Tracks { get; set; }

    [JsonProperty("events")]
    public List<GmEvent> Events { get; set; }

    [JsonProperty("modifiers")]
    public List<object> Modifiers { get; set; } // TODO

    [JsonProperty("isCreationTrack")]
    public bool IsCreationTrack { get; set; }
}
