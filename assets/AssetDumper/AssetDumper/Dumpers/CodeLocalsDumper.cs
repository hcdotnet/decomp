using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("code_locals")]
public sealed class CodeLocalsDumper : AbstractListDumper<UndertaleCodeLocals> {
    protected override void DumpListItem(UndertaleData data, UndertaleCodeLocals item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleCodeLocals>? GetList(UndertaleData data) {
        return data.CodeLocals;
    }
}
