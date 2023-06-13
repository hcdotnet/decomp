using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("extensions")]
public sealed class ExtensionDumper : AbstractListDumper<UndertaleExtension> {
    protected override void DumpListItem(UndertaleData data, UndertaleExtension item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleExtension>? GetList(UndertaleData data) {
        return data.Extensions;
    }
}
