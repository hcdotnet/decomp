using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class Keyframe<T> {
    [JsonProperty("resourceType")]
    public string ResourceType { get; set; }

    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("key")]
    public float Key { get; set; }

    [JsonProperty("length")]
    public float Length { get; set; }

    [JsonProperty("Stretch")]
    public bool Stretch { get; set; }

    [JsonProperty("Disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("IsCreationKey")]
    public bool IsCreationKey { get; set; }

    [JsonProperty("Channels")]
    public Dictionary<int, T> Channels { get; set; }

    [JsonProperty("resourceVersion")]
    public string ResourceVersion { get; set; }
}
