using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public sealed class EmbeddedAudioDumper : AbstractListDumper<UndertaleEmbeddedAudio> {
    public override string Name => "embedded_audio";

    protected override void DumpListItem(UndertaleData data, UndertaleEmbeddedAudio item, FileWriter w) {
        w.Create(item.Data, item.Name.Content + ".wav");
    }

    protected override IList<UndertaleEmbeddedAudio>? GetList(UndertaleData data) {
        return data.EmbeddedAudio;
    }
}
