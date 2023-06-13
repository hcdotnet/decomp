using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("rooms")]
public sealed class RoomDumper : AbstractListDumper<UndertaleRoom> {
    protected override void DumpListItem(UndertaleData data, UndertaleRoom item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleRoom>? GetList(UndertaleData data) {
        return data.Rooms;
    }
}
