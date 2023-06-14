using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public class GmrView {
    [JsonProperty("inherit")]
    public bool Inherit { get; set; }

    [JsonProperty("visible")]
    public bool Visible { get; set; }

    [JsonProperty("xview")]
    public int XView { get; set; }

    [JsonProperty("yview")]
    public int YView { get; set; }

    [JsonProperty("wview")]
    public int WView { get; set; }

    [JsonProperty("hview")]
    public int HView { get; set; }

    [JsonProperty("xport")]
    public int XPort { get; set; }

    [JsonProperty("yport")]
    public int YPort { get; set; }

    [JsonProperty("wport")]
    public int WPort { get; set; }

    [JsonProperty("hport")]
    public int HPort { get; set; }

    [JsonProperty("hborder")]
    public int HBorder { get; set; }

    [JsonProperty("vborder")]
    public int VBorder { get; set; }

    [JsonProperty("hspeed")]
    public int HSpeed { get; set; }

    [JsonProperty("vspeed")]
    public int VSpeed { get; set; }

    [JsonProperty("objectId")]
    public ResourceLinkTarget ObjectId { get; set; }
}
