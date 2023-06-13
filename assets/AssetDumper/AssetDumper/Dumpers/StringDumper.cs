using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public sealed class StringDumper : AbstractListDumper<UndertaleString> {
    public override string Name => "strings";

    private List<string> stringList = new ();

    public override void Dump(UndertaleData data, FileWriter w) {
        stringList = new List<string>();
        base.Dump(data, w);
        w.Create(string.Join("\n", stringList), "strings.txt");
    }

    protected override void DumpListItem(UndertaleData data, UndertaleString item, FileWriter w) {
        stringList.Add(item.Content);
    }

    protected override IList<UndertaleString>? GetList(UndertaleData data) {
        return data.Strings;
    }
}
