using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum GmSoundCompression {
    [JsonProperty("Uncompressed")]
    Uncompressed,

    [JsonProperty("Compressed")]
    Compressed,

    [JsonProperty("DecompressOnLoad")]
    DecompressOnLoad,

    [JsonProperty("CompressedAndStreamed")]
    CompressedAndStreamed,
}
