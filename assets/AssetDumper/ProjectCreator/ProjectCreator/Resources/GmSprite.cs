using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmSprite : ResourceBase {
    [JsonProperty("bboxMode")]
    public BboxMode BboxMode { get; set; }

    [JsonProperty("collisionKind")]
    public SpriteColKind CollisionKind { get; set; }

    [JsonProperty("type")]
    public GmSpriteType Type { get; set; }

    [JsonProperty("origin")]
    public Origin Origin { get; set; }

    [JsonProperty("preMultiplyAlpha")]
    public bool PreMultiplyAlpha { get; set; }

    [JsonProperty("edgeFiltering")]
    public bool EdgeFiltering { get; set; }

    [JsonProperty("collisionTolerance")]
    public uint CollisionTolerance { get; set; }

    [JsonProperty("swfPrecision")]
    public float SwfPrecision { get; set; }

    [JsonProperty("bbox_left")]
    public int BboxLeft { get; set; }

    [JsonProperty("bbox_right")]
    public int BboxRight { get; set; }

    [JsonProperty("bbox_top")]
    public int BboxTop { get; set; }

    [JsonProperty("bbox_bottom")]
    public int BboxBottom { get; set; }

    [JsonProperty("HTile")]
    public bool HTile { get; set; }

    [JsonProperty("VTile")]
    public bool VTile { get; set; }

    [JsonProperty("For3D")]
    public bool For3D { get; set; }

    [JsonProperty("DynamicTexturePage")]
    public bool DynamicTexturePage { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("textureGroupId")]
    public ResourceLinkTarget TextureGroupId { get; set; }

    [JsonProperty("swatchColours")]
    public List<uint>? SwatchColors { get; set; }

    [JsonProperty("gridX")]
    public int GridX { get; set; }

    [JsonProperty("gridY")]
    public int GridY { get; set; }

    [JsonProperty("frames")]
    public List<GmSpriteFrame> Frames { get; set; }

    [JsonProperty("sequence")]
    public GmSequence Sequence;

    [JsonProperty("frameCountIsLength")]
    public bool FrameCountIsLength { get; set; }

    [JsonProperty("userSetLength")]
    public bool UserSetLength { get; set; }

    [JsonProperty("layers")]
    public List<GmImageLayer> Layers { get; set; }

    [JsonProperty("nineSlice")]
    public object? NineSlice { get; set; } // todo: yeah... no
}
