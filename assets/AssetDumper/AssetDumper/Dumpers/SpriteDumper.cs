using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("sprites")]
public sealed class SpriteDumper : AbstractListDumper<UndertaleSprite> {
    protected override void DumpListItem(UndertaleData data, UndertaleSprite item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleSprite>? GetList(UndertaleData data) {
        return data.Sprites;
    }
}
