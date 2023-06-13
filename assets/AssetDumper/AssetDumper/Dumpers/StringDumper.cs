using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public sealed class StringDumper : AbstractListDumper<UndertaleString> {
    public override string Name => "strings";

    public override void Dump(UndertaleData data, FileWriter w) {
        // base.Dump(data, w);

        w.Create(JsonConvert.SerializeObject(GetList(data)!.Select(x => x.Content), Formatting.Indented), "strings.json");
    }

    protected override void DumpListItem(UndertaleData data, UndertaleString item, FileWriter w) { }

    protected override IList<UndertaleString>? GetList(UndertaleData data) {
        return data.Strings;
    }
}
