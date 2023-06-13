using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("global_init_scripts")]
public sealed class GlobalInitDumper : AbstractListDumper<UndertaleGlobalInit> {
    protected override void DumpListItem(UndertaleData data, UndertaleGlobalInit item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleGlobalInit>? GetList(UndertaleData data) {
        return data.GlobalInitScripts;
    }
}
