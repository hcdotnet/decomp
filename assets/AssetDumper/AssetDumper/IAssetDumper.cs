using UndertaleModLib;

namespace AssetDumper;

public interface IAssetDumper {
    string Name { get; }

    bool ShouldDump(UndertaleData data);

    void Dump(UndertaleData data, FileWriter w);
}
