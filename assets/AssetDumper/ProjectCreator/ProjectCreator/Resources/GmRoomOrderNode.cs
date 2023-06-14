using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmRoomOrderNode {
    [JsonProperty("roomId")]
    public ResourceLinkTarget RoomId { get; set; }

    [JsonProperty("groupName")]
    public string GroupName { get; set; }

    [JsonProperty("children")]
    public List<GmRoomOrderNode> Children { get; set; }
}
