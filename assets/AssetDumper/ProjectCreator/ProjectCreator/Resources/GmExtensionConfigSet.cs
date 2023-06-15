using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmExtensionConfigSet {
    [JsonProperty("resourceType")]
    public string ResourceType { get; set; }

    [JsonProperty("resourceVersion")]
    public string ResourceVersion { get; set; }

    [JsonProperty("configurables")]
    public Dictionary<Guid, Dictionary<string, Dictionary<string, string>>>? Configurables { get; set; }
}
