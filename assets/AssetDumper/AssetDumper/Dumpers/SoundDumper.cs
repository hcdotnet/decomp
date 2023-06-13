using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("sound")]
public sealed class SoundDumper : AbstractListDumper<UndertaleSound> {
    protected override void DumpListItem(UndertaleData data, UndertaleSound item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleSound>? GetList(UndertaleData data) {
        return data.Sounds;
    }
}
