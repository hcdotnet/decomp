using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmExtensionFunction : ResourceBase {
    [JsonProperty("externalName")]
    public string ExternalName { get; set; }

    [JsonProperty("kind")]
    public int Kind { get; set; }

    [JsonProperty("help")]
    public string Help { get; set; }

    [JsonProperty("hidden")]
    public bool Hidden { get; set; }

    [JsonProperty("returnType")]
    public int ReturnType { get; set; }

    [JsonProperty("argCount")]
    public int ArgCount { get; set; }

    [JsonProperty("args")]
    public List<int> Args { get; set; }

    [JsonProperty("documentation")]
    public string Documentation { get; set; }
}
