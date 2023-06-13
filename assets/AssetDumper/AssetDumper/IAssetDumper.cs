using UndertaleModLib;

namespace AssetDumper;

public interface IAssetDumper {
    bool ShouldDump(UndertaleData data);

    void Dump(UndertaleData data, FileWriter w);
}
