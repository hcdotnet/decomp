using UndertaleModLib;

namespace AssetDumper.Dumpers;

[Dumper("general_info")]
public sealed class GeneralInfoDumper : IAssetDumper {
    public bool ShouldDump(UndertaleData data) {
        return data.GeneralInfo is not null; // should always be true
    }

    public void Dump(UndertaleData data, FileWriter w) {
        // TODO
    }
}
