using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public enum TargetPlatforms : long {
    [JsonProperty("MacOsX")]
    MacOsX = 2L,

    [JsonProperty("iOS")]
    Ios = 4L,

    [JsonProperty("Android")]
    Android = 8L,

    [JsonProperty("Html5")]
    Html5 = 0x20L,

    [JsonProperty("Windows")]
    Windows = 0x40L,

    [JsonProperty("Ubuntu")]
    Ubuntu = 0x80L,

    [JsonProperty("WindowsPhone8")]
    WindowsPhone8 = 0x1000L,

    [JsonProperty("SteamWorkshop")]
    SteamWorkshop = 0x4000L,

    [JsonProperty("Windows8Javascript")]
    Windows8Javascript = 0x8000L,

    [JsonProperty("TizenJavascript")]
    TizenJavascript = 0x10000L,

    [JsonProperty("Windows_YYC")]
    WindowsYyc = 0x100000L,

    [JsonProperty("Android_YYC")]
    AndroidYyc = 0x200000L,

    [JsonProperty("Windows8")]
    Windows8 = 0x400000L,

    [JsonProperty("TizenNative")]
    TizenNative = 0x800000L,

    [JsonProperty("Tizen_YYC")]
    TizenYyc = 0x1000000L,

    [JsonProperty("iOS_YYC")]
    IosYyc = 0x2000000L,

    [JsonProperty("MacOsX_YYC")]
    MacOsXYyc = 0x4000000L,

    [JsonProperty("Ubuntu_YYC")]
    UbuntuYyc = 0x8000000L,

    [JsonProperty("WindowsPhone8_YYC")]
    WindowsPhone8Yyc = 0x10000000L,

    [JsonProperty("Windows8_YYC")]
    Windows8Yyc = 0x20000000L,

    [JsonProperty("PSVita")]
    PsVita = 0x80000000L,

    [JsonProperty("PS4")]
    Ps4 = 0x100000000L,

    [JsonProperty("PSVita_YYC")]
    PsVitaYyc = 0x1000000000L,

    [JsonProperty("PS4_YYC")]
    Ps4Yyc = 0x2000000000L,

    [JsonProperty("PS3")]
    Ps3 = 0x20000000000L,

    [JsonProperty("PS3_YYC")]
    Ps3Yyc = 0x40000000000L,

    [JsonProperty("GameMakerPlayer")]
    GameMakerPlayer = 0x100000000000L,

    [JsonProperty("AndroidTV")]
    AndroidTv = 0x800000000000L,

    [JsonProperty("AndroidTV_YYC")]
    AndroidTvYyc = 0x1000000000000L,

    [JsonProperty("AmazonFireTV")]
    AmazonFireTv = 0x2000000000000L,

    [JsonProperty("AmazonFireTV_YYC")]
    AmazonFireTvYyc = 0x4000000000000L,

    [JsonProperty("tvOS")]
    TvOs = 0x20000000000000L,

    [JsonProperty("tvOS_YYC")]
    TvOsYyc = 0x40000000000000L,

    [JsonProperty("Switch")]
    Switch = 0x200000000000000L,

    [JsonProperty("Switch_YYC")]
    SwitchYyc = 0x400000000000000L,

    [JsonProperty("PS5")]
    Ps5 = 0x800000000000000L,

    [JsonProperty("PS5_YYC")]
    Ps5Yyc = 0x1000000000000000L,

    [JsonProperty("XboxSeriesXS")]
    XboxSeriesXs = 0x2000000000000000L,

    [JsonProperty("XboxSeriesXS_YYC")]
    XboxSeriesXsYyc = 0x4000000000000000L,

    [JsonProperty("WebAssembly")]
    WebAssembly = long.MinValue,

    [JsonProperty("OperaGX")]
    OperaGx = 0x400000000L,

    [JsonProperty("OldPlatforms")]
    OldPlatforms = 0x6679631BFF1D0EEL,

    [JsonProperty("AllPlatforms")]
    AllPlatforms = -1L,
}
