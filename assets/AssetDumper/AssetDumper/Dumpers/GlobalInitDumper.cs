using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("global_init_scripts")]
public sealed class GlobalInitDumper : AbstractListDumper<UndertaleGlobalInit> {
    public override void Dump(UndertaleData data, FileWriter w) {
        // base.Dump(data, w);

        w.Create(JsonConvert.SerializeObject(data.GlobalInitScripts.Select(x => x.Code.Name.Content), Formatting.Indented), "global_init_scripts.json");
    }

    protected override void DumpListItem(UndertaleData data, UndertaleGlobalInit item, FileWriter w) { }

    protected override IList<UndertaleGlobalInit>? GetList(UndertaleData data) {
        return data.GlobalInitScripts;
    }
}
