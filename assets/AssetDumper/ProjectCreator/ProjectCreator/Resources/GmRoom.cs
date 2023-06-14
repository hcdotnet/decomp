using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmRoom {
    [JsonProperty("isDnd")]
    public bool IsDnd { get; set; }

    [JsonProperty("volume")]
    public float Volume { get; set; }

    [JsonProperty("parentRoom")]
    public ResourceLinkTarget ParentRoom { get; set; }

    [JsonProperty("views")]
    public List<GmrView> Views { get; set; }

    [JsonProperty("layers")]
    public List<GmrLayer> Layers { get; set; }

    [JsonProperty("inheritLayers")]
    public bool InheritLayers { get; set; }

    [JsonProperty("creationCodeFile")]
    public string CreationCodeFile { get; set; }

    [JsonProperty("inheritCode")]
    public bool InheritCode { get; set; }

    [JsonProperty("instanceCreationOrder")]
    public List<GmrInstance> InstanceCreationOrder { get; set; }

    [JsonProperty("inheritCreationOrder")]
    public bool InheritCreationOrder { get; set; }

    // TODO: sequences
    [JsonProperty("sequenceId")]
    public object SequenceId { get; set; }

    [JsonProperty("roomSettings")]
    public GmRoomSettings Settings { get; set; }

    [JsonProperty("viewSettings")]
    public GmRoomViewSettings ViewSettings { get; set; }

    [JsonProperty("physicsSettings")]
    public GmRoomPhysicsSettings PhysicsSettings { get; set; }
}
