using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmSequence : ResourceBase {
    [JsonProperty("spriteId")]
    public ResourceLinkTarget SpriteId { get; set; }

    [JsonProperty("timeUnits")]
    public SequenceTimeUnits TimeUnits { get; set; }

    [JsonProperty("playback")]
    public SequencePlayback Playback { get; set; }

    [JsonProperty("playbackSpeed")]
    public float PlaybackSpeed { get; set; }

    [JsonProperty("playbackSpeedType")]
    public AnimSpeedType PlaybackSpeedType { get; set; }

    [JsonProperty("autoRecord")]
    public bool AutoRecord { get; set; }

    [JsonProperty("volume")]
    public float Volume { get; set; }

    [JsonProperty("headPosition")]
    public float HeadPosition { get; set; }

    [JsonProperty("length")]
    public float Length { get; set; }

    [JsonProperty("events")]
    public KeyframeStore<MessageEventKeyframe> Events { get; set; }

    [JsonProperty("moments")]
    public KeyframeStore<MomentsEventKeyframe> Moments { get; set; }

    [JsonProperty("tracks")]
    public List<GmBaseTrack> Tracks { get; set; }

    [JsonProperty("visibleRange")]
    public Point? VisibleRange { get; set; }

    [JsonProperty("lockOrigin")]
    public bool LockOrigin { get; set; }

    [JsonProperty("showBackdrop")]
    public bool ShowBackdrop { get; set; }

    [JsonProperty("showBackdropImage")]
    public bool ShowBackdropImage { get; set; }

    [JsonProperty("backdropImagePath")]
    public string BackdropImagePath { get; set; }

    [JsonProperty("backdropImageOpacity")]
    public float BackdropImageOpacity { get; set; }

    [JsonProperty("backdropWidth")]
    public int BackdropWidth { get; set; }

    [JsonProperty("backdropHeight")]
    public int BackdropHeight { get; set; }

    [JsonProperty("backdropXOffset")]
    public float BackdropXOffset { get; set; }

    [JsonProperty("backdropYOffset")]
    public float BackdropYOffset { get; set; }

    [JsonProperty("xorigin")]
    public int XOrigin { get; set; }

    [JsonProperty("yorigin")]
    public int YOrigin { get; set; }

    [JsonProperty("eventToFunction")]
    public Dictionary<int, string> EventToFunction { get; set; }

    [JsonProperty("eventStubScript")]
    public ResourceLinkTarget? EventStubScript { get; set; }
}
