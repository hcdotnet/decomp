using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("code")]
public sealed class CodeDumper : AbstractListDumper<UndertaleCode> {
    protected override void DumpListItem(UndertaleData data, UndertaleCode item, FileWriter w) {
        // TODO: figure out how we want to dump code, and if we even want to
    }

    protected override IList<UndertaleCode>? GetList(UndertaleData data) {
        return data.Code;
    }
}
