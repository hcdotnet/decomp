using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum GmSpriteType {
    [JsonProperty("Bitmap")]
    Bitmap,

    [JsonProperty("SWF")]
    Swf,

    [JsonProperty("Spine")]
    Spine,

    [JsonProperty("Vector")]
    Vector,
}
