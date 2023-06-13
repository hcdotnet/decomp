using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("paths")]
public sealed class PathDumper : AbstractListDumper<UndertalePath> {
    protected override void DumpListItem(UndertaleData data, UndertalePath item, FileWriter w) {
        // TODO: unused
    }

    protected override IList<UndertalePath>? GetList(UndertaleData data) {
        return data.Paths;
    }
}
