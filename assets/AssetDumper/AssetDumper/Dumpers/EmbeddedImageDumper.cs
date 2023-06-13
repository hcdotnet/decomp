using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Util;

namespace AssetDumper.Dumpers;

[Dumper("embedded_images")]
public sealed class EmbeddedImageDumper : AbstractListDumper<UndertaleEmbeddedImage> {
    protected override void DumpListItem(UndertaleData data, UndertaleEmbeddedImage item, FileWriter w) {
        var worker = new TextureWorker();
        worker.ExportAsPNG(item.TextureEntry, w.GetPath(item.Name.Content));
    }

    protected override IList<UndertaleEmbeddedImage>? GetList(UndertaleData data) {
        return data.EmbeddedImages;
    }
}
