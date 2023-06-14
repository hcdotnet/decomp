using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmRoomPhysicsSettings {
    [JsonProperty("inheritPhysicsSettings")]
    public bool InheritPhysicsSettings { get; set; }

    [JsonProperty("PhysicsWorld")]
    public bool PhysicsWorld { get; set; }

    [JsonProperty("PhysicsWorldGravityX")]
    public float PhysicsWorldGravityX { get; set; }

    [JsonProperty("PhysicsWorldGravityY")]
    public float PhysicsWorldGravityY { get; set; }

    [JsonProperty("PhysicsWorldPixToMetres")]
    public float PhysicsWorldPixelsToMeters { get; set; }
}
