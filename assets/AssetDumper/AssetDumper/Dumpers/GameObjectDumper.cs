using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("game_objects")]
public sealed class GameObjectDumper : AbstractListDumper<UndertaleGameObject> {
    protected override void DumpListItem(UndertaleData data, UndertaleGameObject item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleGameObject>? GetList(UndertaleData data) {
        return data.GameObjects;
    }
}
