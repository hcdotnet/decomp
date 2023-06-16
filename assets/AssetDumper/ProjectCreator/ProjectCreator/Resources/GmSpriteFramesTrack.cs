using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmSpriteFramesTrack : GmBaseTrack {
    [JsonProperty("spriteId")]
    public ResourceLinkTarget? SpriteId { get; set; }

    [JsonProperty("keyframes")]
    public KeyframeStore<SpriteFrameKeyframe> Keyframes { get; set; }
}
