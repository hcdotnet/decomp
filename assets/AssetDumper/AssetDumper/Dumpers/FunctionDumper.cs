using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("functions")]
public sealed class FunctionDumper : AbstractListDumper<UndertaleFunction> {
    protected override void DumpListItem(UndertaleData data, UndertaleFunction item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleFunction>? GetList(UndertaleData data) {
        return data.Functions;
    }
}
