using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmMainOptions : GmOptionsBase {
    [JsonProperty("option_gameguid")]
    public string OptionGameGuid { get; set; }

    [JsonProperty("option_gameid")]
    public string OptionGameId { get; set; }

    [JsonProperty("option_game_speed")]
    public int OptionGameSpeed { get; set; }

    [JsonProperty("option_mips_for_3d_textures")]
    public bool OptionMipsFor3DTextures { get; set; }

    [JsonProperty("option_draw_colour")]
    public uint OptionDrawColor { get; set; }

    [JsonProperty("option_window_colour")]
    public uint OptionWindowColor { get; set; }

    [JsonProperty("option_steam_app_id")]
    public string OptionSteamAppId { get; set; }

    [JsonProperty("option_sci_usesci")]
    public bool OptionSciUseSci { get; set; }

    [JsonProperty("option_author")]
    public string OptionAuthor { get; set; }

    [JsonProperty("option_collision_compatibility")]
    public bool OptionCollisionCompatibility { get; set; }

    [JsonProperty("option_copy_on_write_enabled")]
    public bool OptionCopyOnWriteEnabled { get; set; }

    [JsonProperty("option_spine_license")]
    public bool OptionSpineLicense { get; set; }

    [JsonProperty("option_template_image")]
    public string OptionTemplateImage { get; set; }

    [JsonProperty("option_template_icon")]
    public string OptionTemplateIcon { get; set; }

    [JsonProperty("option_template_description")]
    public string? OptionTemplateDescription { get; set; }
}
