using System.Collections.Generic;
using UndertaleModLib;

namespace AssetDumper.Dumpers;

public abstract class AbstractListDumper<T> : IAssetDumper {
    public bool ShouldDump(UndertaleData data) {
        var list = GetList(data);
        return list is not null && list.Count > 0;
    }

    public virtual void Dump(UndertaleData data, FileWriter w) {
        foreach (var item in GetList(data)!)
            DumpListItem(data, item, w);
    }

    protected abstract void DumpListItem(UndertaleData data, T item, FileWriter w);

    protected abstract IList<T>? GetList(UndertaleData data);
}
