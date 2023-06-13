using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

// Called tile sets, but they're backgrounds.
[Dumper("tile_sets")]
public sealed class TileSetDumper : AbstractListDumper<UndertaleBackground> {
    protected override void DumpListItem(UndertaleData data, UndertaleBackground item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleBackground>? GetList(UndertaleData data) {
        return data.Backgrounds;
    }
}
