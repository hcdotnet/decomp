using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("code")]
public sealed class CodeDumper : AbstractListDumper<UndertaleCode> {
    protected override void DumpListItem(UndertaleData data, UndertaleCode item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleCode>? GetList(UndertaleData data) {
        return data.Code;
    }
}
