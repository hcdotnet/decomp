using UndertaleModLib;

namespace AssetDumper;

public interface IAssetDumper {
    bool ShouldDump();

    void Dump(UndertaleData data, FileWriter w);
}
