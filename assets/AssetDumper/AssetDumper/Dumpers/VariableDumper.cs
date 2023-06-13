using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("variables")]
public sealed class VariableDumper : AbstractListDumper<UndertaleVariable> {
    protected override void DumpListItem(UndertaleData data, UndertaleVariable item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleVariable>? GetList(UndertaleData data) {
        return data.Variables;
    }
}
