using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("timelines")]
public sealed class TimelineDumper : AbstractListDumper<UndertaleTimeline> {
    protected override void DumpListItem(UndertaleData data, UndertaleTimeline item, FileWriter w) {
        // TODO: unused
    }

    protected override IList<UndertaleTimeline>? GetList(UndertaleData data) {
        return data.Timelines;
    }
}
