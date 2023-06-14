using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources; 

public enum DefaultScriptType {
    [JsonProperty("None")]
    None,
    
    [JsonProperty("GML")]
    Gml,
    
    [JsonProperty("GMLVisual")]
    GmlVisual,
}
