using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum EffectPropType {
    [JsonProperty("Real")]
    Real,

    [JsonProperty("Color")]
    Color,

    [JsonProperty("Sampler")]
    Sampler,
}
