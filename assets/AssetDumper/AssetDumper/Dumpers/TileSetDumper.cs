using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Util;

namespace AssetDumper.Dumpers;

public class TileSetInfo {
    public bool Transparent { get; init; }

    public bool Smooth { get; init; }

    public bool Preload { get; init; }

    public uint Gms2UnknownAlways2 { get; init; }

    public uint Gms2TileWidth { get; init; }

    public uint Gms2TileHeight { get; init; }

    public uint Gms2OutputBorderX { get; init; }

    public uint Gms2OutputBorderY { get; init; }

    public uint Gms2TileColumns { get; init; }

    public uint Gms2ItemsPerTileCount { get; init; }

    public uint Gms2TileCount { get; init; }

    public uint Gms2UnknownAlwaysZero { get; init; }

    public long Gms2FrameLength { get; init; }

    public List<uint> Gms2TileIds { get; init; }

    public static TileSetInfo FromGameMakerObject(UndertaleBackground background) {
        return new TileSetInfo {
            Transparent = background.Transparent,
            Smooth = background.Smooth,
            Preload = background.Preload,
            Gms2UnknownAlways2 = background.GMS2UnknownAlways2,
            Gms2TileWidth = background.GMS2TileWidth,
            Gms2TileHeight = background.GMS2TileHeight,
            Gms2OutputBorderX = background.GMS2OutputBorderX,
            Gms2OutputBorderY = background.GMS2OutputBorderY,
            Gms2TileColumns = background.GMS2TileColumns,
            Gms2ItemsPerTileCount = background.GMS2ItemsPerTileCount,
            Gms2TileCount = background.GMS2TileCount,
            Gms2UnknownAlwaysZero = background.GMS2UnknownAlwaysZero,
            Gms2FrameLength = background.GMS2FrameLength,
            Gms2TileIds = background.GMS2TileIds.Select(x => x.ID).ToList()
        };
    }
}

// Called tile sets, but they're backgrounds.
[Dumper("tile_sets")]
public sealed class TileSetDumper : AbstractListDumper<UndertaleBackground> {
    protected override void DumpListItem(UndertaleData data, UndertaleBackground item, FileWriter w) {
        var path = w.GetRelativePath(item.Name.Content);

        w.Create(JsonConvert.SerializeObject(TileSetInfo.FromGameMakerObject(item), Formatting.Indented), path, "tile_set_info.json");

        var worker = new TextureWorker();
        worker.ExportAsPNG(item.Texture, w.GetPath(path, item.Name.Content + ".png"));
    }

    protected override IList<UndertaleBackground>? GetList(UndertaleData data) {
        return data.Backgrounds;
    }
}
