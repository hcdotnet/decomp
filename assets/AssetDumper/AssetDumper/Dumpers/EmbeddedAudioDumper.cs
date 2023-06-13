using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("embedded_audio")]
public sealed class EmbeddedAudioDumper : AbstractListDumper<UndertaleEmbeddedAudio> {
    protected override void DumpListItem(UndertaleData data, UndertaleEmbeddedAudio item, FileWriter w) {
        w.Create(item.Data, item.Name.Content + ".wav");
    }

    protected override IList<UndertaleEmbeddedAudio>? GetList(UndertaleData data) {
        return data.EmbeddedAudio;
    }
}
