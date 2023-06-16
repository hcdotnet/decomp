using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum BuiltinTrack {
    [JsonProperty("UserDefined")]
    UserDefined,

    [JsonProperty("__X__")]
    X,

    [JsonProperty("__Y__")]
    Y,

    [JsonProperty("__ScaleX__")]
    __ScaleX__,

    [JsonProperty("__ScaleY__")]
    __ScaleY__,

    [JsonProperty("Gain")]
    Gain,

    [JsonProperty("Pitch")]
    Pitch,

    [JsonProperty("Falloff")]
    Falloff,

    [JsonProperty("Rotation")]
    Rotation,

    [JsonProperty("BlendAdd")]
    BlendAdd,

    [JsonProperty("BlendMultiply")]
    BlendMultiply,

    [JsonProperty("ClippingMask")]
    ClippingMask,

    [JsonProperty("Mask")]
    Mask,

    [JsonProperty("Subject")]
    Subject,

    [JsonProperty("Position")]
    Position,

    [JsonProperty("Scale")]
    Scale,

    [JsonProperty("Origin")]
    Origin,

    [JsonProperty("ImageSpeed")]
    ImageSpeed,

    [JsonProperty("ImageIndex")]
    ImageIndex,

    [JsonProperty("Group")]
    Group,

    [JsonProperty("FrameSize")]
    FrameSize,

    [JsonProperty("CharacterSpacing")]
    CharacterSpacing,

    [JsonProperty("LineSpacing")]
    LineSpacing,

    [JsonProperty("ParagraphSpacing")]
    ParagraphSpacing,
}
