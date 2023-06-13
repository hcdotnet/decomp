using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("texture_group_information")]
public sealed class TextureGroupInfoDumper : AbstractListDumper<UndertaleTextureGroupInfo> {
    protected override void DumpListItem(UndertaleData data, UndertaleTextureGroupInfo item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleTextureGroupInfo>? GetList(UndertaleData data) {
        return data.TextureGroupInfo;
    }
}
