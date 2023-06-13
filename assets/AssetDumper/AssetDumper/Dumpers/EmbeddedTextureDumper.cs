using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("embedded_textures")]
public sealed class EmbeddedTextureDumper : AbstractListDumper<UndertaleEmbeddedTexture> {
    protected override void DumpListItem(UndertaleData data, UndertaleEmbeddedTexture item, FileWriter w) {
        w.Create(item.TextureData.TextureBlob, item.Name.Content + ".png");
    }

    protected override IList<UndertaleEmbeddedTexture>? GetList(UndertaleData data) {
        return data.EmbeddedTextures;
    }
}
