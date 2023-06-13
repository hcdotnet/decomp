using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("audio_groups")]
public sealed class AudioGroupDumper : AbstractListDumper<UndertaleAudioGroup> {
    protected override void DumpListItem(UndertaleData data, UndertaleAudioGroup item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleAudioGroup>? GetList(UndertaleData data) {
        return data.AudioGroups;
    }
}
