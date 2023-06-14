using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmEffectProp {
    [JsonProperty("type")]
    public EffectPropType Type { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
}
