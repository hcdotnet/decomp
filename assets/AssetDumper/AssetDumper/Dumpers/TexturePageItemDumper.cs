using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("texture_page_items")]
public sealed class TexturePageItemDumper : AbstractListDumper<UndertaleTexturePageItem> {
    protected override void DumpListItem(UndertaleData data, UndertaleTexturePageItem item, FileWriter w) {
        // TODO: eventually stop dumping sprites and make them point to here
    }

    protected override IList<UndertaleTexturePageItem>? GetList(UndertaleData data) {
        return data.TexturePageItems;
    }
}
