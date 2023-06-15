using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmSound : ResourceBase {
    [JsonProperty("conversionMode")]
    public GmConversionMode ConversionMode { get; set; }

    [JsonProperty("compression")]
    public GmSoundCompression Compression { get; set; }

    [JsonProperty("volume")]
    public float Volume { get; set; }

    [JsonProperty("preload")]
    public bool Preload { get; set; }

    [JsonProperty("bitRate")]
    public int BitRate { get; set; }

    [JsonProperty("sampleRate")]
    public int SampleRate { get; set; }

    [JsonProperty("type")]
    public GmSoundType Type { get; set; }

    [JsonProperty("bitDepth")]
    public GmSoundBitDepth BitDepth { get; set; }

    [JsonProperty("audioGroupId")]
    public ResourceLinkTarget AudioGroupId { get; set; }

    [JsonProperty("soundFile")]
    public string SoundFile { get; set; }

    [JsonProperty("duration")]
    public float Duration { get; set; }
}
