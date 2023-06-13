using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers; 

[Dumper("scripts")]
public sealed class ScriptDumper : AbstractListDumper<UndertaleScript> {
    protected override void DumpListItem(UndertaleData data, UndertaleScript item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleScript>? GetList(UndertaleData data) {
        return data.Scripts;
    }
}
