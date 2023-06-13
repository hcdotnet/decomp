using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("fonts")]
public sealed class FontDumper : AbstractListDumper<UndertaleFont> {
    protected override void DumpListItem(UndertaleData data, UndertaleFont item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleFont>? GetList(UndertaleData data) {
        return data.Fonts;
    }
}
