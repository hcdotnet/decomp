using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Util;

namespace AssetDumper.Dumpers;

[Dumper("texture_page_items", Large = true)]
public sealed class TexturePageItemDumper : AbstractListDumper<UndertaleTexturePageItem> {
    protected override void DumpListItem(UndertaleData data, UndertaleTexturePageItem item, FileWriter w) {
        // TODO: I believe this includes every texture in the game, including
        // things covered by sprites and what-not. Can we just dump these and
        // have others point to them?

        var worker = new TextureWorker();
        worker.ExportAsPNG(item, w.GetPath(item.Name.Content + ".png"));
    }

    protected override IList<UndertaleTexturePageItem>? GetList(UndertaleData data) {
        return data.TexturePageItems;
    }
}
